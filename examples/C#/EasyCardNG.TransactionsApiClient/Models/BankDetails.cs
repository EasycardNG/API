using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Integration.Models.PaymentDetails
{
    /// <summary>
    /// For billing deal only. For invoice and payment transaction use <see cref="BankTransferDetails"></see>
    /// </summary>
    public class BankDetails
    {
        public BankDetails()
        {
            PaymentType = PaymentTypeEnum.Bank;
        }

        public PaymentTypeEnum PaymentType { get; set; }

        [JsonProperty(PropertyName = "bank")]
        [Required]
        public int? Bank { get; set; }

        [JsonProperty(PropertyName = "bankBranch")]
        [Required]
        public int? BankBranch { get; set; }

        [JsonProperty(PropertyName = "bankAccount")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 6)]
        public string BankAccount { get; set; }
    }
}
