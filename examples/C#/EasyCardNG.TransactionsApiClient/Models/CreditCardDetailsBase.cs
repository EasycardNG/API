using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Helpers
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreditCardDetailsBase
    {
        [Required]
        [StringLength(19, MinimumLength = 9)]
        [RegularExpression("^[0-9]*$")]
        public string CardNumber { get; set; }

        [Required]
        [JsonConverter(typeof(CardExpirationConverter))]
        public virtual CardExpiration CardExpiration { get; set; }

        [StringLength(20)]
        public string CardVendor { get; set; }

        [StringLength(20)]
        public string CardBrand { get; set; }

        [StringLength(20)]
        public string Solek { get; set; }

        
        [StringLength(50, MinimumLength = 2)]
        public string CardOwnerName { get; set; }

        [StringLength(20)]
        public string CardOwnerNationalID { get; set; }

        //[RegularExpression(@"^;\d{15,17}=\d{19,21}\?$")]
        public string CardReaderInput { get; set; }
    }
}
