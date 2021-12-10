using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stargazer.Extensions.Newtonsoft.Json.LongToStringConvert
{
    public class LongToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long) || objectType == typeof(long?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if(objectType == typeof(long))
                return JToken.ReadFrom(reader).Value<long>();
            else
                return JToken.ReadFrom(reader).Value<long?>();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }
    }
}
