using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Shared.Api.Models.Enums
{
    public enum QuickDateFilterTypeEnum : short
    {
        [EnumMember(Value = "today")]
        Today = 0,

        [EnumMember(Value = "yesterday")]
        Yesterday = 1,

        [EnumMember(Value = "thisWeek")]
        ThisWeek = 2,

        [EnumMember(Value = "lastWeek")]
        LastWeek = 3,

        [EnumMember(Value = "last30Days")]
        Last30Days = 4,

        [EnumMember(Value = "thisMonth")]
        ThisMonth = 5,

        [EnumMember(Value = "lastMonth")]
        LastMonth = 6,

        [EnumMember(Value = "last3Months")]
        Last3Months = 7,
    }
}
