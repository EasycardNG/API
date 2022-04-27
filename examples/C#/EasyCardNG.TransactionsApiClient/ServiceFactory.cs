using Shared.Helpers;
using Shared.Helpers.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCardNG.TransactionsApiClient
{
    public class ServiceFactory
    {
        private readonly Configuration configuration;

        private readonly WebApiClient webApiClient = new WebApiClient();

        private readonly IWebApiClientTokenService tokenService;

        private static IDictionary<Environment, Configuration> configurations = new Dictionary<Environment, Configuration>()
        {
            {
                Environment.SANDBOX,
                new Configuration
                {
                    IdentityApiAddress = "https://ecng-identity.azurewebsites.net",
                    MetadataApiAddress = "https://ecng-profile.azurewebsites.net",
                    TransactionApiAddress = "https://ecng-transactions.azurewebsites.net",
                    CheckoutAddress = "https://ecng-checkout.azurewebsites.net"
                }
            },
            {
                Environment.LIVE,
                new Configuration
                {
                    IdentityApiAddress = "https://identity.e-c.co.il",
                    MetadataApiAddress = "https://merchant.e-c.co.il",
                    TransactionApiAddress = "https://api.e-c.co.il",
                    CheckoutAddress = "https://checkout.e-c.co.il"
                }
            },
            {
                Environment.DEV,
                new Configuration
                {
                    IdentityApiAddress = "https://ecng-identity.azurewebsites.net",
                    MetadataApiAddress = "https://localhost:44339",
                    TransactionApiAddress = "https://localhost:44322",
                    CheckoutAddress = "https://ecng-checkout.azurewebsites.net"
                }
            }
        };

        public ServiceFactory(string privateKey, Environment environment)
        {
            configuration = configurations[environment];

            tokenService = new TokensService(privateKey, webApiClient, configuration);
        }

        public TransactionsApiClient GetTransactionsApiClient()
        {
            return new TransactionsApiClient(tokenService, webApiClient, configuration);
        }
    }
}
