using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace BinanceAPI
{
    static class ConvertHelper
    {
        public static T DataConvert<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string ObtainEnumValue<T>(T data)
        {
            var info = JsonConvert.SerializeObject(data, new StringEnumConverter());
            return JsonConvert.DeserializeObject<string>(info);
        }

        public static DateTime ConvertServerTime(string data)
        {
            var o = JsonConvert.DeserializeObject<JObject>(data);
            return JsTimeConverter.TimeFromMs(Convert.ToInt64(o["serverTime"]));
        }
    }

    class JsTimeConverter : JsonConverter
    {
        public static DateTime TimeFromMs(long ms)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ms).DateTime;
        }

        public static long TimeToMs(DateTime time)
        {
            return new DateTimeOffset(time).ToUnixTimeMilliseconds();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return TimeFromMs((long)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(TimeToMs((DateTime)value));
        }
    }

    class PairConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var o = JArray.Load(reader);

            return new PairInfo()
            {
                Price = Convert.ToDecimal(o[0]),
                Quantity = Convert.ToDecimal(o[1]),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    class CurrentKlineConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var o = (JObject.Load(reader))["k"] as JObject;

            return new CurrentKlineInfo()
            {
                OpenTime = JsTimeConverter.TimeFromMs(Convert.ToInt64(o["t"])),
                CloseTime = JsTimeConverter.TimeFromMs(Convert.ToInt64(o["T"])),
                Open = Convert.ToDecimal(o["o"]),
                High = Convert.ToDecimal(o["h"]),
                Low = Convert.ToDecimal(o["l"]),
                Close = Convert.ToDecimal(o["c"]),
                Volume = Convert.ToDecimal(o["v"]),                
                QuoteVolume = Convert.ToDecimal(o["q"]),
                TradeNumber = Convert.ToInt32(o["n"]),
                BuyTakerVolume = Convert.ToDecimal(o["V"]),
                BuyTakerQuoteVolume = Convert.ToDecimal(o["Q"]),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    class HistoryKlineConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var o = JArray.Load(reader);

            return new HistoryKlineInfo()
            {
                OpenTime = JsTimeConverter.TimeFromMs(Convert.ToInt64(o[0])),
                Open = Convert.ToDecimal(o[1]),
                High = Convert.ToDecimal(o[2]),
                Low = Convert.ToDecimal(o[3]),
                Close = Convert.ToDecimal(o[4]),
                Volume = Convert.ToDecimal(o[5]),
                CloseTime = JsTimeConverter.TimeFromMs(Convert.ToInt64(o[6])),
                QuoteVolume = Convert.ToDecimal(o[7]),
                TradeNumber = Convert.ToInt32(o[8]),
                BuyTakerVolume = Convert.ToDecimal(o[9]),
                BuyTakerQuoteVolume = Convert.ToDecimal(o[10]),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
