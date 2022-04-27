using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Shared.Helpers;
using Shared.Integration.Models;
using Shared.Integration.Models.PaymentDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Shared.Enums;
using Enums = Transactions.Shared.Enums;
using IntegrationModels = Shared.Integration.Models;

namespace Transactions.Api.Models.Transactions
{
    /// <summary>
    /// Payment transaction details
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TransactionResponse
    {
        /// <summary>
        /// Primary transaction reference (UUId)
        /// </summary>
        public Guid PaymentTransactionID { get; set; }

        /// <summary>
        /// Legal transaction day
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Date-time when transaction created initially in UTC
        /// </summary>
        public DateTime? TransactionTimestamp { get; set; }

        /// <summary>
        /// Reference to initial billing deal
        /// </summary>
        public Guid? InitialTransactionID { get; set; }

        /// <summary>
        /// Current deal number (billing)
        /// </summary>
        public int? CurrentDeal { get; set; }

        /// <summary>
        /// EasyCard terminal UUId
        /// </summary>
        public Guid? TerminalID { get; set; }

        /// <summary>
        /// EasyCard terminal name
        /// </summary>
        public string TerminalName { get; set; }

        /// <summary>
        /// Processing status
        /// </summary>
        [EnumDataType(typeof(TransactionStatusEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatusEnum Status { get; set; }

        /// <summary>
        /// Payment Type
        /// </summary>
        [EnumDataType(typeof(PaymentTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentTypeEnum PaymentTypeEnum { get; set; }

        [EnumDataType(typeof(QuickStatusFilterTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public QuickStatusFilterTypeEnum QuickStatus { get; set; }

        /// <summary>
        /// Status of finalization operations in case of failed transaction, rejection or cancelation
        /// </summary>
        public string FinalizationStatus { get; set; }

        /// <summary>
        /// Generic transaction type
        /// </summary>
        public TransactionTypeEnum TransactionType { get; set; }

        /// <summary>
        /// Special transaction type
        /// </summary>
        public SpecialTransactionTypeEnum SpecialTransactionType { get; set; }

        /// <summary>
        /// J3, J4, J5
        /// </summary>
        public JDealTypeEnum JDealType { get; set; }

        /// <summary>
        /// Transaction J5 expired date (in gengeral after 1 day)
        /// </summary>
        public DateTime? TransactionJ5ExpiredDate { get; set; }

        /// <summary>
        /// Rejection Reason
        /// </summary>
        public string RejectionReason { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public CurrencyEnum Currency { get; set; }

        /// <summary>
        /// Telephone deal or Regular (megnetic)
        /// </summary>
        public CardPresenceEnum CardPresence { get; set; }

        /// <summary>
        /// Number Of Installments
        /// </summary>
        public int NumberOfPayments { get; set; }

        /// <summary>
        /// This transaction amount
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// Initial installment payment
        /// </summary>
        public decimal InitialPaymentAmount { get; set; }

        /// <summary>
        /// TotalAmount = InitialPaymentAmount + (NumberOfInstallments - 1) * InstallmentPaymentAmount
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Amount of one instalment payment
        /// </summary>
        public decimal InstallmentPaymentAmount { get; set; }

        /// <summary>
        /// Credit card information
        /// </summary>
        public CreditCardDetails CreditCardDetails { get; set; }

        /// <summary>
        /// Bank transfer information
        /// </summary>
        public BankTransferDetails BankTransferDetails { get; set; }

        /// <summary>
        /// Stored credit card details token reference
        /// </summary>
        public string CreditCardToken { get; set; }

        /// <summary>
        /// Deal information
        /// </summary>
        public DealDetails DealDetails { get; set; }

        /// <summary>
        /// Shva details
        /// </summary>
        public object ShvaTransactionDetails { get; set; }

        /// <summary>
        /// Date-time when transaction status updated
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Transaction can be transmitted manually
        /// </summary>
        public bool AllowTransmission { get; set; }

        /// <summary>
        /// Transaction transmission cannot be canceled manually
        /// </summary>
        public bool AllowTransmissionCancellation { get; set; }

        /// <summary>
        /// Reference to billing schedule which produced this transaction
        /// </summary>
        public Guid? BillingDealID { get; set; }

        /// <summary>
        /// Rejection Reason Message (in case of rejected transaction)
        /// </summary>
        public string RejectionMessage { get; set; }

        /// <summary>
        /// Deal tax rate
        /// </summary>
        public decimal VATRate { get; set; }

        /// <summary>
        /// Total deal tax amount. VATTotal = NetTotal * VATRate
        /// </summary>
        public decimal VATTotal { get; set; }

        /// <summary>
        /// Deal amount before tax. PaymentRequestAmount = NetTotal + VATTotal
        /// </summary>
        public decimal NetTotal { get; set; }

        /// <summary>
        /// Request ID
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Generated invoice ID
        /// </summary>
        public Guid? InvoiceID { get; set; }

        /// <summary>
        /// Create document for transaction
        /// </summary>
        public bool IssueInvoice { get; set; }

        /// <summary>
        /// Payment transaction origin. For example "Checkout" means that transaction created by consumer via Checkout Page, "Billing" means that transaction generated based on billing schedule etc.
        /// </summary>
        [EnumDataType(typeof(DocumentOriginEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public DocumentOriginEnum DocumentOrigin { get; set; }

        /// <summary>
        /// Reference to initial payment link creation request
        /// </summary>
        public Guid? PaymentRequestID { get; set; }

        /// <summary>
        /// Any advanced payload which will be stored in EasyCard and then can be obtained using "GetTransaction"
        /// </summary>
        public JObject Extension { get; set; }

        public object BitTransactionDetails { get; set; }

        public decimal? TotalRefund { get; set; }
    }
}
