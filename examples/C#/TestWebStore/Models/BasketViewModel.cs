using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    public class BasketViewModel
    {
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public decimal? Quantity { get; set; }

        /// <summary>
        /// Consumer name
        /// </summary>
        public string Name { get; set; }

        public string NationalID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Order reference inside merchant's system
        /// </summary>
        public string InternalOrderID { get; set; }

        /// <summary>
        /// Can be used if merchant's system keeps ConsumerID from ECNG
        /// </summary>
        public Guid? ConsumerID { get; set; }

        /// <summary>
        /// Consumer ID in merchant's system
        /// </summary>
        public string ConsumerExternalReference { get; set; }

        public bool IssueInvoice { get; set; }

        public bool AllowPinPad { get; set; }

        /// <summary>
        /// User can enter custom deal amount (relevant for partial payments, donaions etc.)
        /// </summary>
        public bool UserAmount { get; set; }

        /// <summary>
        /// Refund transaction
        /// </summary>
        public bool Refund { get; set; }
    }
}
