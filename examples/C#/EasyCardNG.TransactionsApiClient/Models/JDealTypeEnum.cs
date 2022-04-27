using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Integration.Models
{
    public enum JDealTypeEnum : short
    {
        /// <summary>
        /// Check
        /// </summary>
        [EnumMember(Value = "J2")]
        J2 = 1,

        /// <summary>
        /// Regular deal
        /// </summary>
        [EnumMember(Value = "J4")]
        J4 = 0,

        /// <summary>
        /// Block card
        /// </summary>
        [EnumMember(Value = "J5")]
        J5 = 2
    }
}
