using System;

namespace TestWebStore.Models
{
    public class BillingDealInternal
    {
        public string InternalOrderID { get; set; }

        public string BillingDealID { get; set; }

        public Guid? ConsumerID { get; set; }

        public decimal? Amount { get; set; }

        public string ProductName { get; set; }

        public string Name { get; set; }

        public string NationalID { get; set; }

        public string Email { get; set; }
    }
}
