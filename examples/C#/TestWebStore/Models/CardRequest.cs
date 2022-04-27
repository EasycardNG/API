using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    public class CardRequest
    {
        /// <summary>
        /// Deal description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Consumer name
        /// </summary>
        public string Name { get; set; }

        public string NationalID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Guid? ConsumerID { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string RedirectUrl { get; set; }

        /// <summary>
        /// Key for merchant's system - to have ability to validate redirect
        /// </summary>
        public string ApiKey { get; set; }

        public bool IssueInvoice { get; set; }

        public bool AllowPinPad { get; set; }
    }
}
