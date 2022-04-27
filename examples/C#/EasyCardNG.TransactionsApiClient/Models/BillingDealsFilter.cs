using Shared.Api.Models;
using Shared.Api.Models.Enums;

using Shared.Helpers;
using Shared.Integration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transactions.Api.Models.Billing
{
    public class BillingDealsFilter : FilterBase
    {
        public Guid? TerminalID { get; set; }

        public Guid? BillingDealID { get; set; }

        public CurrencyEnum? Currency { get; set; }

        public QuickDateFilterTypeEnum? QuickDateFilter { get; set; }

        public bool? FilterDateByNextScheduledTransaction { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }

        public Guid? ConsumerID { get; set; }

        public Guid? CreditCardTokenID { get; set; }

        public string CardNumber { get; set; }

        public string CardOwnerNationalID { get; set; }

        /// <summary>
        /// Performs search by both consumer name and card owner name
        /// </summary>
        public string ConsumerName { get; set; }

        /// <summary>
        /// End-customer Email
        /// </summary>
        public string ConsumerEmail { get; set; }

        /// <summary>
        /// Billing deals that can be manually triggered
        /// </summary>
        public bool Actual { get; set; }

        public bool Finished { get; set; }

        public bool Paused { get; set; }

        public bool HasError { get; set; }

        public PaymentTypeEnum? PaymentType { get; set; }

        /// <summary>
        /// Merchant deal reference
        /// </summary>
        public string DealReference { get; set; }

        public bool InvoiceOnly { get; set; }

        public string Origin { get; set; }

        public bool OnlyActive { get; set; }

        public bool InProgress { get; set; }

        public bool CreditCardExpired { get; set; }

        public string ConsumerExternalReference { get; set; }
    }
}
