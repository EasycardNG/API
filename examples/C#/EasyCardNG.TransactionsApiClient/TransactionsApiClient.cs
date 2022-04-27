using MerchantProfileApi.Models.Billing;
using Shared.Api.Models;
using Shared.Api.Models.Enums;
using Shared.Helpers;
using Shared.Helpers.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Transactions.Api.Models.Billing;
using Transactions.Api.Models.PaymentRequests;
using Transactions.Api.Models.Tokens;
using Transactions.Api.Models.Transactions;

namespace EasyCardNG.TransactionsApiClient
{
    public class TransactionsApiClient
    {
        private readonly IWebApiClientTokenService tokensService;
        private readonly WebApiClient webApiClient;
        private readonly Configuration configuration;

        internal TransactionsApiClient(IWebApiClientTokenService tokensService, WebApiClient webApiClient, Configuration configuration)
        {
            this.tokensService = tokensService;
            this.webApiClient = webApiClient;
            this.configuration = configuration;
        }

        public string GetCheckoutUrl()
        {
            return configuration.CheckoutAddress;
        }

        public async Task<SummariesResponse<ConsumerSummary>> GetConsumers(ConsumersFilter filter)
        {
            var consumers = await webApiClient.Get<SummariesResponse<ConsumerSummary>>(configuration.MetadataApiAddress, $"/api/consumers", filter, BuildHeaders);

            return consumers;
        }

        public async Task<OperationResponse> CreateConsumer(ConsumerRequest request)
        {
            try
            {
                var consumerResp = await webApiClient.Post<OperationResponse>(configuration.MetadataApiAddress, $"/api/consumers", request, BuildHeaders);

                return consumerResp;
            }
            catch (WebApiClientErrorException clientError)
            {
                return clientError.TryConvert(new OperationResponse { Message = clientError.Message, Status = StatusEnum.Error });
            }
        }

        public async Task<TransactionResponse> GetTransaction(string transactionID)
        {
            var transaction = await webApiClient.Get<TransactionResponse>(configuration.TransactionApiAddress, $"/api/transactions/{transactionID}", null, BuildHeaders);

            return transaction;
        }

        public async Task<OperationResponse> CreatePaymentIntent(PaymentRequestCreate model)
        {
            try
            {
                var res = await webApiClient.Post<OperationResponse>(configuration.TransactionApiAddress, $"/api/paymentIntent", model, BuildHeaders);

                return res;
            }
            catch (WebApiClientErrorException clientError)
            {
                return clientError.TryConvert(new OperationResponse { Message = clientError.Message, Status = StatusEnum.Error });
            }
        }

        public async Task<SummariesResponse<BillingDealSummary>> GetBillingDeals(BillingDealsFilter filter)
        {
            var transaction = await webApiClient.Get<SummariesResponse<BillingDealSummary>>(configuration.TransactionApiAddress, $"/api/billing", filter, BuildHeaders);

            return transaction;
        }

        public async Task<BillingDealResponse> GetBillingDeal(Guid billingDealID)
        {
            var transaction = await webApiClient.Get<BillingDealResponse>(configuration.TransactionApiAddress, $"/api/billing/{billingDealID}", null, BuildHeaders);

            return transaction;
        }

        public async Task<OperationResponse> CreateBillingDeal(BillingDealRequest model)
        {
            var res = await webApiClient.Post<OperationResponse>(configuration.TransactionApiAddress, $"/api/billing", model, BuildHeaders);

            return res;
        }

        public async Task<OperationResponse> UpdateBillingDeal(Guid billingDealID, BillingDealUpdateRequest model)
        {
            try
            {
                var res = await webApiClient.Put<OperationResponse>(configuration.TransactionApiAddress, $"/api/billing/{billingDealID}", model, BuildHeaders);

                return res;
            }
            catch (WebApiClientErrorException clientError)
            {
                return clientError.TryConvert(new OperationResponse { Message = clientError.Message, Status = StatusEnum.Error });
            }
        }

        public async Task<SummariesResponse<CreditCardTokenSummary>> GetTokens(CreditCardTokenFilter filter)
        {
            var res = await webApiClient.Get<SummariesResponse<CreditCardTokenSummary>>(configuration.TransactionApiAddress, $"/api/cardtokens", filter, BuildHeaders);

            return res;
        }

        public async Task<OperationResponse> DeleteToken(string key)
        {
            var res = await webApiClient.Delete<OperationResponse>(configuration.TransactionApiAddress, $"/api/cardtokens/{key}", BuildHeaders);

            return res;
        }

        private async Task<NameValueCollection> BuildHeaders()
        {
            var token = await tokensService.GetToken();

            NameValueCollection headers = new NameValueCollection();

            if (token != null)
            {
                headers.Add("Authorization", new AuthenticationHeaderValue("Bearer", token.AccessToken).ToString());
            }

            return headers;
        }
    }
}
