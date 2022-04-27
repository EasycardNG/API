using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Integration.Models.Invoicing
{
    public enum InvoiceTypeEnum : short
    {
        [EnumMember(Value = "invoice")]
        Invoice = 1,

        [EnumMember(Value = "invoiceWithPaymentInfo")]
        InvoiceWithPaymentInfo = 2,

        [EnumMember(Value = "creditNote")]
        CreditNote = 3,

        [EnumMember(Value = "paymentInfo")]
        PaymentInfo = 4,

        [EnumMember(Value = "refundInvoice")]
        RefundInvoice = 5,
    }
}
