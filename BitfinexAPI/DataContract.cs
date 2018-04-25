using System;
using System.Collections.Generic;

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

    public class BaseInfo : Dictionary<string, object>
    {
    }

    public class TradeInfo
    {
        public decimal price;
        public decimal amount;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime timestamp;
        public string type;
        public long tid;
        public string exchange;
    }

    public class PairInfo
    {
        public decimal price;
        public decimal amount;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime timestamp;
    }

    public class OrderBookInfo
    {
        public List<PairInfo> asks;
        public List<PairInfo> bids;
    }

    public class BalanceInfo
    {
        public string type;
        public string currency;
        public decimal amount;
        public decimal available;
    }

    public class PositionInfo
    {
        public long id;
        public string symbol;
        public string status;
        [JsonProperty("base")]
        public decimal base_price;
        public decimal amount;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime timestamp;
        public decimal swap;
        public decimal pl;
    }

    public class OrderInfo
    {
        public long id;
        public string symbol;
        public string exchange;
        public decimal price;
        public decimal avg_execution_price;
        public string side;
        public string type;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime timestamp;
        public bool is_live;
        public bool is_cancelled;
        public bool is_hidden;
        public bool was_forced;
        public decimal original_amount;
        public decimal remaining_amount;
        public decimal executed_amount;
    }
}
