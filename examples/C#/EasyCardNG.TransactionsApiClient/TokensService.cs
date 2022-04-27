using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Helpers;
using Shared.Helpers.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCardNG.TransactionsApiClient
{
    /// <summary>
    /// This is sample implementation. You can use RestSharp, IdentityModel or other library instead
    /// </summary>
    public class TokensService : IWebApiClientTokenService
    {
        private readonly string privateKey;
        private readonly WebApiClient webApiClient;
        private readonly Configuration configuration;

        private TokenResponse Token { get; set; }

        private DateTime ExpiryTime { get; set; }

        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

        internal TokensService(string privateKey, WebApiClient webApiClient, Configuration configuration)
        {
            this.privateKey = privateKey;
            this.webApiClient = webApiClient;
            this.configuration = configuration;
        }

        public async Task<TokenResponse> GetToken(NameValueCollection headers = null)
        {
            if (this.Token != null)
            {
                if (ExpiryTime >= DateTime.UtcNow)
                {
                    return Token;
                }
            }

            var res = await webApiClient.PostRawFormRawResponse(configuration.IdentityApiAddress, "/connect/token",
                new Dictionary<string, string> { { "client_id", "terminal" }, { "grant_type", "terminal_rest_api" }, { "authorizationKey", privateKey } });
            var tokenResponse = await TokenResponse.FromHttpResponseAsync<TokenResponse>(res);

            if (tokenResponse.IsError)
            {
                throw new ApplicationException($"Could not retrieve token: {tokenResponse.Error} ({tokenResponse.ErrorType}). {tokenResponse.ErrorDescription}");
            }

            //set Token to the new token and set the expiry time to the new expiry time
            Token = tokenResponse;
            ExpiryTime = DateTime.UtcNow.AddSeconds(Token.ExpiresIn);

            //return fresh token
            return Token;
        }
    }
}
