using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace BitfinexAPI
{
    class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTimeOffset.FromUnixTimeSeconds((long)decimal.Parse(reader.Value.ToString())).DateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(new DateTimeOffset((DateTime)value).ToUnixTimeSeconds());
        }
    }

    public enum OrderSide
    {
        [EnumMember(Value = "buy")]
        BUY,
        [EnumMember(Value = "sell")]
        SELL,
    }

    public enum OrderType
    {
        [EnumMember(Value = "limit")]
        LIMIT,
        [EnumMember(Value = "market")]
        MARKET,
        [EnumMember(Value = "exchange limit")]
        EXCHANGE_LIMIT,
        [EnumMember(Value = "exchange market")]
        EXCHANGE_MARKET,
    }
}
