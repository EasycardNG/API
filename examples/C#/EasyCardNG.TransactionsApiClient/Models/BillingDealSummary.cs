using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Helpers;
using Shared.Integration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Shared.Enums;
using Transactions.Shared.Models;
using SharedIntegration = Shared.Integration;

namespace Transactions.Api.Models.Billing
{
    public class BillingDealSummary
    {
        public Guid BillingDealID { get; set; }

        public Guid TerminalID { get; set; }

        public Guid MerchantID { get; set; }

        public decimal TransactionAmount { get; set; }

        [EnumDataType(typeof(CurrencyEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyEnum Currency { get; set; }

        public DateTime? BillingDealTimestamp { get; set; }

        public DateTime? NextScheduledTransaction { get; set; }

        public string ConsumerName { get; set; }

        /// <summary>
        /// Billing Schedule
        /// </summary>
        public BillingSchedule BillingSchedule { get; set; }

        public string CardNumber { get; set; }

        public bool? CardExpired { get; set; }

        public bool Active { get; set; }

        public int? CurrentDeal { get; set; }

        
        public DateTime? PausedFrom { get; set; }

        
        public DateTime? PausedTo { get; set; }

        public bool Paused { get; set; }

        public PaymentTypeEnum PaymentType { get; set; }

        /// <summary>
        /// Deal information
        /// </summary>
        
        public SharedIntegration.Models.DealDetails DealDetails { get; set; }

        public bool InvoiceOnly { get; set; }

        /// <summary>
        /// Stored credit card details token
        /// </summary>
        public Guid? CreditCardToken { get; set; }
    }
}
