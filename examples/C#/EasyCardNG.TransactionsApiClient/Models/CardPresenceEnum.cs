using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.Integration.Models
{
    /// <summary>
    /// Is the card physically scanned
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardPresenceEnum : short
    {
        /// <summary>
        /// Telephone deal
        /// </summary>
        [EnumMember(Value = "cardNotPresent")]
        CardNotPresent = 0,

        /// <summary>
        /// Magnetic
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular = 1,
    }
}
