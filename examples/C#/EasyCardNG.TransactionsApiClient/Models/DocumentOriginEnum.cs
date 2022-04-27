using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Transactions.Shared.Enums
{
    /// <summary>
    /// Document origin (primarely payment transaction origin)
    /// </summary>
    public enum DocumentOriginEnum : short
    {
        /// <summary>
        /// Document created manually by merchant user using Merchant's UI
        /// </summary>
        [EnumMember(Value = "UI")]
        UI = 0,

        /// <summary>
        /// Document created via API
        /// </summary>
        [EnumMember(Value = "API")]
        API = 1,

        /// <summary>
        /// Document created by consumer using Checkout Page
        /// </summary>
        [EnumMember(Value = "checkout")]
        Checkout = 2,

        /// <summary>
        /// Document generated based on billing schedule
        /// </summary>
        [EnumMember(Value = "billing")]
        Billing = 3,

        /// <summary>
        /// Transaction created using pinpad device (or other device)
        /// </summary>
        [EnumMember(Value = "device")]
        Device = 4,

        /// <summary>
        /// Document created by consumer using Checkout Page with a payment link
        /// </summary>
        [EnumMember(Value = "paymentRequest")]
        PaymentRequest = 5,

        /// <summary>
        /// Document created by consumer using Bit
        /// </summary>
        [EnumMember(Value = "bit")]
        Bit = 6,

        /// <summary>
        /// Document created by consumer using Ecwid
        /// </summary>
        [EnumMember(Value = "ecwid")]
        Ecwid = 7
    }
}
