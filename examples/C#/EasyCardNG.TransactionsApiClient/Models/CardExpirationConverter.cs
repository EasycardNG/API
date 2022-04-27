using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public class CardExpirationConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var cardexp = value as CardExpiration;
            writer.WriteValue(cardexp.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return string.Empty;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                return CreditCardHelpers.ParseCardExpiration(reader.Value.ToString());
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CardExpiration);
        }
    }
}
