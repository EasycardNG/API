using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCardNG.TransactionsApiClient
{
    public class Configuration
    {
        public string TransactionApiAddress { get; set; }

        public string MetadataApiAddress { get; set; }

        public string IdentityApiAddress { get; set; }

        public string CheckoutAddress { get; set; }
    }
}
