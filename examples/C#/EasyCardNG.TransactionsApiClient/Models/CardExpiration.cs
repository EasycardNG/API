using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Helpers
{
    public class CardExpiration
    {
        public CardExpiration()
        {
        }

        [Range(20, 90)]
        [Required(AllowEmptyStrings = false)]
        public int? Year { get; set; }

        [Range(1, 12)]
        [Required(AllowEmptyStrings = false)]
        public int? Month { get; set; }

        public DateTime? ToDate()
        {
            if (Year.HasValue && Month.HasValue)
            {
                return new DateTime(Year.Value + 2000, Month.Value, DateTime.DaysInMonth(Year.Value + 2000, Month.Value));
            }
            else
            {
                return null;
            }
        }

        public bool Expired
        {
            get
            {
                return ToDate() < DateTime.UtcNow;
            }

            set
            {
            }
        }
    }
}
