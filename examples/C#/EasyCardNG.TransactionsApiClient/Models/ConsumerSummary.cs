using Shared.Integration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantProfileApi.Models.Billing
{
    public class ConsumerSummary
    {
        public Guid ConsumerID { get; set; }

        public Guid TerminalID { get; set; }

        /// <summary>
        /// End-customer Email
        /// </summary>
        public string ConsumerEmail { get; set; }

        public string ConsumerName { get; set; }

        public string ConsumerPhone { get; set; }

        public string ConsumerNationalID { get; set; }

        public Address ConsumerAddress { get; set; }

        public string ExternalReference { get; set; }

        /// <summary>
        /// External ID inside https://woocommerce.com system
        /// </summary>
        public string WoocommerceID { get; set; }

        /// <summary>
        /// External ID inside https://www.ecwid.com system
        /// </summary>
        public string EcwidID { get; set; }
    }
}
