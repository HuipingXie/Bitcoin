using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BinanceAPI
{
    public interface IBinanceData
    {
    }

    [JsonConverter(typeof(PairConverter))]
    public class PairInfo : IBinanceData
    {
        public decimal Price;
        public decimal Quantity;
    }

    public class OrderBookInfo : IBinanceData
    {
        [JsonProperty("lastUpdateId")]
        public int LastUpdateId;

        [JsonProperty("asks")]
        public List<PairInfo> Asks;

        [JsonProperty("bids")]
        public List<PairInfo> Bids;
    }

    public class TradeInfo : IBinanceData
    {
        [JsonProperty("p")]
        public decimal Price;

        [JsonProperty("q")]
        public decimal Quantity;

        [JsonProperty("T")]
        [JsonConverter(typeof(JsTimeConverter))]
        public DateTime TradeTime;

        [JsonProperty("m")]
        public bool IsBuyerMade;
    }

    public class KlineInfo : IBinanceData
    {
        public DateTime OpenTime;
        public DateTime CloseTime;
        public decimal Open;
        public decimal Close;
        public decimal High;
        public decimal Low;
        public decimal Volume;
        public decimal QuoteVolume;
        public int TradeNumber;
        public decimal BuyTakerVolume;
        public decimal BuyTakerQuoteVolume;
    }

    [JsonConverter(typeof(HistoryKlineConverter))]
    public class HistoryKlineInfo : KlineInfo, IBinanceData
    {
    }

    [JsonConverter(typeof(CurrentKlineConverter))]
    public class CurrentKlineInfo : KlineInfo, IBinanceData
    {
    }

    public class OrderReceiptInfo : IBinanceData
    {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("orderId")]
        public int OrderId;

        [JsonProperty("clientOrderId")]
        public string ClientOrderId;
    }

    public class AccountOrderInfo : IBinanceData
    {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("orderId")]
        public int OrderId;

        [JsonProperty("clientOrderId")]
        public string ClientOrderId;

        [JsonProperty("price")]
        public decimal Price;

        [JsonProperty("origQty")]
        public decimal OriginalQuantity;

        [JsonProperty("executedQty")]
        public decimal ExecutedQuantity;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType Type;

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side;

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status;

        [JsonProperty("timeInForce")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderTimeInForce TimeInForce;

        [JsonProperty("time")]
        [JsonConverter(typeof(JsTimeConverter))]
        public DateTime TradeTime;

        [JsonProperty("stopPrice")]
        public decimal StopPrice;

        [JsonProperty("icebergQty")]
        public decimal IcebergQuantity;

        [JsonProperty("isWorking")]
        public bool IsWorking;
    }

    public class AccountTradeInfo : IBinanceData
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("orderId")]
        public int OrderId;

        [JsonProperty("price")]
        public decimal Price;

        [JsonProperty("qty")]
        public decimal Quantity;

        [JsonProperty("commission")]
        public decimal Commission;

        [JsonProperty("commissionAsset")]
        public string CommissionAsset;

        [JsonProperty("time")]
        [JsonConverter(typeof(JsTimeConverter))]
        public DateTime Time;

        [JsonProperty("isBuyer")]
        public bool IsBuyer;

        [JsonProperty("isMaker")]
        public bool IsMaker;

        [JsonProperty("isBestMatch")]
        public bool IsBestMatch;
    }
}
