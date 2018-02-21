using System.Runtime.Serialization;

namespace BinanceAPI
{
    public enum SymbolStatus
    {
        PRE_TRADING,
        TRADING,
        POST_TRADING,
        END_OF_DAY,
        HALT,
        AUCTION_MATCH,
        BREAK,
    }

    public enum OrderType
    {
        LIMIT,
        MARKET,
        STOP_LOSS,
        STOP_LOSS_LIMIT,
        TAKE_PROFIT,
        TAKE_PROFIT_LIMIT,
        LIMIT_MAKER,
    }

    public enum OrderStatus
    {
        NEW,
        PARTIALLY_FILLED,
        FILLED,
        CANCELED,
        PENDING_CANCEL,
        REJECTED,
        EXPIRED,
    }

    public enum OrderTimeInForce
    {
        GTC,
        IOC,
        FOK,
    }

    public enum OrderSide
    {
        BUY,
        SELL,
    }

    public enum KlineInterval
    {
        [EnumMember(Value = "1m")]
        OneMinute,
        [EnumMember(Value = "3m")]
        ThreeMinutes,
        [EnumMember(Value = "5m")]
        FiveMinutes,
        [EnumMember(Value = "15m")]
        FifteenMinutes,
        [EnumMember(Value = "30m")]
        ThirtyMinutes,
        [EnumMember(Value = "1h")]
        OneHour,
        [EnumMember(Value = "2h")]
        TwoHours,
        [EnumMember(Value = "4h")]
        FourHours,
        [EnumMember(Value = "6h")]
        SixHours,
        [EnumMember(Value = "8h")]
        EightHours,
        [EnumMember(Value = "12h")]
        TwelveHours,
        [EnumMember(Value = "1d")]
        OneDay,
        [EnumMember(Value = "3d")]
        ThreeDays,
        [EnumMember(Value = "1w")]
        OneWeek,
        [EnumMember(Value = "1M")]
        OneMonth,
    }
}
