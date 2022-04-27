using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    public class WebHookData : ITableEntity
    {
        public const string TransactionCreated = "TransactionCreated";

        public const string TransactionRejected = "TransactionRejected";

        public const string CardTokenCreated = "CardTokenCreated";

        public const string CardTokenDeleted = "CardTokenDeleted";

        public const string CreditCardExpired = "CreditCardExpired";

        public const string BillingDealCreated = "BillingDealCreated";

        public const string BillingDealUpdated = "BillingDealUpdated";

        public const string InvoiceGenerated = "InvoiceGenerated";

        public const string InvoiceGenerationFailed = "InvoiceGenerationFailed";

        public const string ConsumerCreated = "ConsumerCreated";

        public const string ConsumerUpdated = "ConsumerUpdated";

        public Guid? MerchantID { get; set; }

        public Guid? TerminalID { get; set; }

        public string CorrelationId { get; set; }

        public string EventName { get; set; }

        public string EntityType { get; set; }

        public string EntityReference { get; set; }

        public string EntityExternalReference { get; set; }

        public DateTime? EventTimestamp { get; set; }

        public bool IsFailureEvent { get; set; }

        public string ErrorMesage { get; set; }

        public string EventID
        {
            get => this.RowKey;

            set
            {
                this.RowKey = value;
            }
        }

        public string PartitionKey { get; set; } = "1";

        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        public string Payload { get; set; }
    }
}
