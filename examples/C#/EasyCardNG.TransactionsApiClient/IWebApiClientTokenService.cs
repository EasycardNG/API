using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Shared.Helpers.Security
{
    public interface IWebApiClientTokenService
    {
        Task<TokenResponse> GetToken(NameValueCollection headers = null);
    }
}
