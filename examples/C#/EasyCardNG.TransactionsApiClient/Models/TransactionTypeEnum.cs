using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Integration.Models
{
    /// <summary>
    /// Generic transaction type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionTypeEnum : short
    {
        /// <summary>
        /// Simple deal type
        /// </summary>
        [EnumMember(Value = "regularDeal")]
        RegularDeal = 0,

        /// <summary>
        /// Deal to pay by parts
        /// </summary>
        [EnumMember(Value = "installments")]
        Installments = 1,

        /// <summary>
        /// Credit deal
        /// </summary>
        [EnumMember(Value = "credit")]
        Credit = 2,

        /// <summary>
        /// Credit deal
        /// </summary>
        [EnumMember(Value = "immediate")]
        Immediate = 3,
    }
}
