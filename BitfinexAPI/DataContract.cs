using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitfinexAPI
{
    public class BaseInfo : Dictionary<string, object>
    {
    }

    public class TradeInfo
    {
        public decimal price;
        public decimal amount;
        [JsonConverter(typeof(TimeConverter))]
        public DateTime timestamp;
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide type;
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
        public decimal? price;
        public decimal avg_execution_price;
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide side;
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType type;
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
