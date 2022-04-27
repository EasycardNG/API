using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Integration.Models.PaymentDetails
{
    public class BankTransferDetails : BankDetails
    {
        public BankTransferDetails()
        {
            PaymentType = PaymentTypeEnum.Bank;
        }

        [JsonProperty(PropertyName = "dueDate")]
        public DateTime? DueDate { get; set; }

        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
    }
}
