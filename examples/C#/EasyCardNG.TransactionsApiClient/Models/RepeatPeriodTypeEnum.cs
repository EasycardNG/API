using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Transactions.Shared.Enums
{
    public enum RepeatPeriodTypeEnum
    {
        [EnumMember(Value = "oneTime")]
        OneTime = 0,

        [EnumMember(Value = "monthly")]
        Monthly = 1,

        [EnumMember(Value = "biMonthly")]
        BiMonthly = 2,

        [EnumMember(Value = "quarter")]
        Quarter = 3,

        [EnumMember(Value = "halfYear")]
        HalfYear = 6,

        [EnumMember(Value = "year")]
        Year = 12,
    }
}
