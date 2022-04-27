using Newtonsoft.Json;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transactions.Api.Models.Transactions
{
    /// <summary>
    /// Does not store full card number. Used 123456****1234 pattern
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreditCardDetails : CreditCardDetailsBase
    {
    }
}
