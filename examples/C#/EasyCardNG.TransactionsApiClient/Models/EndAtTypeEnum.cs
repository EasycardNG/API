using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Transactions.Shared.Enums
{
    public enum EndAtTypeEnum
    {
        [EnumMember(Value = "never")]
        Never = 0,

        [EnumMember(Value = "specifiedDate")]
        SpecifiedDate = 1,

        [EnumMember(Value = "afterNumberOfPayments")]
        AfterNumberOfPayments = 2
    }
}
