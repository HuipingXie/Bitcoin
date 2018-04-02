using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinanceAPI
{
    public class BinanceMethod
    {
        string _symbol;

        static string _apiKey;
        static string _secretKey;

        public BinanceMethod(string symbol, string apiKey, string secretKey)
        {
            _symbol = symbol.ToUpper();

            _apiKey = apiKey;
            _secretKey = secretKey;
        }

        string JointSymbol(string apiName)
        {
            return apiName + "?symbol=" + _symbol;
        }

        string Append(string key, object value)
        {
            return "&" + key + "=" + value.ToString();
        }

        string AppendPeriod(DateTime startTime, DateTime endTime)
        {
            return "&startTime=" + JsTimeConverter.TimeToMs(startTime).ToString()
                + "&endTime=" + JsTimeConverter.TimeToMs(endTime).ToString();
        }

        async Task<T> Process<T>(string args, SecurityType token, InvokeMethod method = InvokeMethod.GET)
        {
            return await AccessRestApi.InvokeHttpCall<T>(args, method, token, _apiKey, _secretKey);
        }

        public async Task<OrderBookInfo> GetOrderBook(int limit = 0)
        {
            return await Process<OrderBookInfo>(
                JointSymbol("/api/v1/depth") + Append("limit", limit),
                SecurityType.MARKET_DATA);
        }

        public async Task<List<TradeInfo>> GetAggregateTrades(DateTime startTime, DateTime endTime)
        {
            return await Process<List<TradeInfo>>(
                JointSymbol("/api/v1/aggTrades") + AppendPeriod(startTime, endTime),
                SecurityType.MARKET_DATA);
        }

        public async Task<List<HistoryKlineInfo>> GetKlines(DateTime startTime, DateTime endTime, KlineInterval interval)
        {
            return await Process<List<HistoryKlineInfo>>(
                JointSymbol("/api/v1/klines")
                + AppendPeriod(startTime, endTime)
                + Append("interval", ConvertHelper.ObtainEnumValue(interval)),
                SecurityType.MARKET_DATA);
        }

        public async Task<AccountInfo> GetAccountInfo()
        {
            return await Process<AccountInfo>(
                "/api/v3/account?", SecurityType.USER_DATA);
        }

        public async Task<List<AccountTradeInfo>> GetAccountTrades()
        {
            return await Process<List<AccountTradeInfo>>(
                JointSymbol("/api/v3/myTrades"), SecurityType.USER_DATA);
        }

        public async Task<List<AccountOrderInfo>> GetOpenOrders()
        {
            return await Process<List<AccountOrderInfo>>(
                JointSymbol("/api/v3/openOrders"), SecurityType.USER_DATA);
        }

        public async Task<List<AccountOrderInfo>> GetAllOrders()
        {
            return await Process<List<AccountOrderInfo>>(
                JointSymbol("/api/v3/allOrders"), SecurityType.USER_DATA);
        }

        public async Task<AccountOrderInfo> QueryOrder(int orderId)
        {
            return await Process<AccountOrderInfo>(
                JointSymbol("/api/v3/order") + Append("orderId", orderId),
                SecurityType.USER_DATA);
        }

        public async Task<OrderReceiptInfo> CancelOrder(int orderId)
        {
            return await Process<OrderReceiptInfo>(
                JointSymbol("/api/v3/order") + Append("orderId", orderId),
                SecurityType.TRADE,
                InvokeMethod.DELETE);
        }

        public async Task<OrderReceiptInfo> NewOrder(
            OrderSide side,
            OrderType type,
            decimal quantity,
            decimal? price = null,
            OrderTimeInForce? timeInForce = null)
        {
            string ep = JointSymbol("/api/v3/order")
                + Append("newOrderRespType", "ACK")
                + Append("side", side)
                + Append("type", type)
                + Append("quantity", quantity);

            switch (type)
            {
                case OrderType.LIMIT:
                    ep += Append("price", price.Value);
                    ep += Append("timeInForce", timeInForce.Value);
                    break;
                case OrderType.MARKET:
                    break;
                default:
                    break;
            }

            return await Process<OrderReceiptInfo>(ep, SecurityType.TRADE, InvokeMethod.POST);
        }
    }
}
