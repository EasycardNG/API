using Newtonsoft.Json.Linq;
using Shared.Helpers;
using Shared.Integration.Models;
using Shared.Integration.Models.Invoicing;
using Shared.Integration.Models.PaymentDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Api.Models.Transactions;
using Transactions.Shared.Enums;
using Transactions.Shared.Models;
using SharedIntegration = Shared.Integration;

namespace Transactions.Api.Models.Billing
{
    public class BillingDealResponse
    {
        /// <summary>
        /// Primary transaction reference
        /// </summary>
        public Guid BillingDealID { get; set; }

        /// <summary>
        /// Date-time when deal created initially in UTC
        /// </summary>
        public DateTime? BillingDealTimestamp { get; set; }

        /// <summary>
        /// Reference to initial transaction
        /// </summary>
        public Guid? InitialTransactionID { get; set; }

        /// <summary>
        /// Terminal
        /// </summary>
        public Guid? TerminalID { get; set; }

        /// <summary>
        /// EasyCard terminal name
        /// </summary>
        public string TerminalName { get; set; }

        /// <summary>
        /// Merchant
        /// </summary>
        public Guid? MerchantID { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public CurrencyEnum Currency { get; set; }

        /// <summary>
        /// This transaction amount
        /// </summary>
        public decimal TransactionAmount { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// TotalAmount = TransactionAmount * NumberOfPayments
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Current deal (billing)
        /// </summary>
        public int? CurrentDeal { get; set; }

        /// <summary>
        /// Date-time when last created initially in UTC
        /// </summary>
        public DateTime? CurrentTransactionTimestamp { get; set; }

        /// <summary>
        /// Reference to last deal
        /// </summary>
        public Guid? CurrentTransactionID { get; set; }

        /// <summary>
        /// Date-time when next transaction should be generated
        /// </summary>
        public DateTime? NextScheduledTransaction { get; set; }

        /// <summary>
        /// Credit card information (just to display)
        /// </summary>
        public Transactions.CreditCardDetails CreditCardDetails { get; set; }

        /// <summary>
        /// Bank account information
        /// </summary>
        public BankDetails BankDetails { get; set; }

        /// <summary>
        /// Stored credit card details token
        /// </summary>
        public Guid? CreditCardToken { get; set; }

        /// <summary>
        /// Deal information
        /// </summary>
        public SharedIntegration.Models.DealDetails DealDetails { get; set; }

        /// <summary>
        /// Billing Schedule
        /// </summary>
        public BillingSchedule BillingSchedule { get; set; }

        /// <summary>
        /// Date-time when transaction status updated
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Concurrency key
        /// </summary>
        public byte[] UpdateTimestamp { get; set; }

        public string OperationDoneBy { get; set; }

        public Guid? OperationDoneByID { get; set; }

        public string CorrelationId { get; set; }

        public string SourceIP { get; set; }

        public bool Active { get; set; }

        public bool? CardExpired { get; set; }

        public bool? TokenNotAvailable { get; set; }

        /// <summary>
        /// Invoice details
        /// </summary>
        public InvoiceDetails InvoiceDetails { get; set; }

        /// <summary>
        /// Create document for transaction
        /// </summary>
        public bool IssueInvoice { get; set; }

        public bool InvoiceOnly { get; set; }

        public decimal VATRate { get; set; }

        public decimal VATTotal { get; set; }

        public decimal NetTotal { get; set; }

        public DateTime? PausedFrom { get; set; }

        public DateTime? PausedTo { get; set; }

        public bool Paused { get; set; }

        public PaymentTypeEnum PaymentType { get; set; }

        public string LastError { get; set; }

        public string LastErrorCorrelationID { get; set; }

        public IEnumerable<JObject> PaymentDetails { get; set; }

        public int? FailedAttemptsCount { get; set; }
    }
}
