using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Shared.Helpers;
using Shared.Integration.Models;
using Shared.Integration.Models.Invoicing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IntegrationModels = Shared.Integration.Models;

namespace Transactions.Api.Models.PaymentRequests
{
    /// <summary>
    /// Create a link to Checkout Page
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PaymentRequestCreate
    {
        /// <summary>
        /// Deal information (optional)
        /// </summary>
        public IntegrationModels.DealDetails DealDetails { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [EnumDataType(typeof(CurrencyEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyEnum Currency { get; set; }

        /// <summary>
        /// Deal amount including VAT. This amount will be displayed on Checkout Page. Consumer can override this amount in case if UserAmount flag specified.
        /// </summary>
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal? PaymentRequestAmount { get; set; }

        /// <summary>
        /// Due date of payment link
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Installment payments details (should be omitted in case of regular deal)
        /// </summary>
        public InstallmentDetails InstallmentDetails { get; set; }

        /// <summary>
        /// Invoice details. In case if omitted default values will be used. Ignored in case if "IssueInvoice" is false
        /// </summary>
        public InvoiceDetails InvoiceDetails { get; set; }

        /// <summary>
        /// Create document - Invoice, Receipt etc. If omitted, default terminal settings will be used
        /// </summary>
        public bool? IssueInvoice { get; set; }

        /// <summary>
        /// Enables PinPad button on checkout page
        /// </summary>
        public bool? AllowPinPad { get; set; }

        /// <summary>
        /// Deal tax rate. Can be omitted if only PaymentRequestAmount specified - in this case VAT rate from terminal settings will be used
        /// </summary>
        [Range(0, 1)]
        [DataType(DataType.Currency)]
        public decimal? VATRate { get; set; }

        /// <summary>
        /// Total deal tax amount. VATTotal = NetTotal * VATRate. Can be omitted if only PaymentRequestAmount specified
        /// </summary>
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal? VATTotal { get; set; }

        /// <summary>
        /// Deal amount before tax. PaymentRequestAmount = NetTotal + VATTotal. Can be omitted if only PaymentRequestAmount specified
        /// </summary>
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal? NetTotal { get; set; }

        /// <summary>
        /// Generate link to Checkout Page to create refund
        /// </summary>
        public bool IsRefund { get; set; }

        /// <summary>
        /// Url to merchant's web site. Base url should be configured in terminal settings. You can add any details to query string.
        /// </summary>
        [StringLength(1000)]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Consumer can override PaymentRequestAmount
        /// </summary>
        public bool UserAmount { get; set; }

        /// <summary>
        /// Any advanced payload which will be stored in EasyCard and then can be obtained using "GetTransaction"
        /// </summary>
        public JObject Extension { get; set; }
    }
}
