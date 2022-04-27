using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Shared.Helpers
{
    public static class CreditCardHelpers
    {
        public static CardExpiration ParseCardExpiration(string expirationStr)
        {
            if (string.IsNullOrWhiteSpace(expirationStr))
            {
                return null;
            }

            expirationStr = expirationStr.Replace(" ", string.Empty);

            var parts = expirationStr.Split("/");

            if (parts.Length != 2)
            {
                return null;
            }

            int.TryParse(parts[0], out var month);

            if (month < 1 || month > 12)
            {
                return null;
            }

            int.TryParse(parts[1], out var year);

            if (year < 18 || year > 99)
            {
                return null;
            }

            return new CardExpiration() { Year = year, Month = month };
        }

        public static string ParseCardExpiration(CardExpiration cardExp)
        {
            if (cardExp == null)
            {
                return string.Empty;
            }

            DateTime expirationDate = new DateTime(cardExp.Year ?? 1999, cardExp.Month ?? 0, 1);
            return expirationDate.ToString("MM'/'yy");
        }

        public static CardExpiration ParseCardExpiration(DateTime? expirationDate)
        {
            if (expirationDate == null)
            {
                return null;
            }

            return new CardExpiration { Year = expirationDate.Value.Year - 2000, Month = expirationDate.Value.Month };
        }

        public static string FormatCardExpiration(DateTime? expirationDate)
        {
            if (expirationDate == null)
            {
                return null;
            }

            return expirationDate.Value.ToString("MM'/'yy");
        }


    }
}
