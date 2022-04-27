using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Integration.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpecialTransactionTypeEnum : short
    {
        [EnumMember(Value = "regularDeal")]
        RegularDeal = 0,

        // TODO: rename it - it is any deal with stored cc
        [EnumMember(Value = "initialDeal")]
        InitialDeal = 1,

        [EnumMember(Value = "refund")]
        Refund = -1,
    }
}
