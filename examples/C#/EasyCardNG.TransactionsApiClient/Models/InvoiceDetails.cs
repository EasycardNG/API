using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Integration.Models.Invoicing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Integration.Models.Invoicing
{
    public class InvoiceDetails
    {
        [EnumDataType(typeof(InvoiceTypeEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public InvoiceTypeEnum InvoiceType { get; set; }

        [StringLength(250)]
        public string InvoiceSubject { get; set; }

        // TODO: validation
        public string[] SendCCTo { get; set; }
    }
}
