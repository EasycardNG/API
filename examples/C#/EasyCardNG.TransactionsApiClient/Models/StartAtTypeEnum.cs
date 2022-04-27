using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Transactions.Shared.Enums
{
    public enum StartAtTypeEnum
    {
        [EnumMember(Value = "today")]
        Today = 0,

        [EnumMember(Value = "specifiedDate")]
        SpecifiedDate = 1
    }
}
