using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Transactions.Shared.Enums;

namespace Transactions.Shared.Models
{
    public class BillingSchedule
    {
        public RepeatPeriodTypeEnum RepeatPeriodType { get; set; }

        public StartAtTypeEnum StartAtType { get; set; }

        
        public DateTime? StartAt { get; set; }

        public EndAtTypeEnum EndAtType { get; set; }

        
        public DateTime? EndAt { get; set; }

        public int? EndAtNumberOfPayments { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
