using System.Runtime.Serialization;

namespace BitfinexAPI
{
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
