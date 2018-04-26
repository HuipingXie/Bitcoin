using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitfinexAPI
{
    public class BitfinexMethod
    {
        string _apiKey;
        string _secretKey;

        public BitfinexMethod(string apiKey, string secretKey)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
        }

        BaseInfo GeneratePayload(string path)
        {
            var args = new BaseInfo();
            args.Add("request", path);
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return args;
        }

        async Task<T> Process<T>(string path)
        {
            return await AccessRestApi.InvokeHttpCall<T>(path);
        }

        async Task<T> Process<T>(BaseInfo args)
        {
            return await AccessRestApi.InvokeHttpCall<T>(
                (string)args["request"], args, _apiKey, _secretKey);
        }

        public async Task<List<TradeInfo>> GetTrades(string symbol)
        {
            return await Process<List<TradeInfo>>("/v1/trades/" + symbol);
        }

        public async Task<OrderBookInfo> GetOrderBook(string symbol)
        {
            return await Process<OrderBookInfo>("/v1/book/" + symbol);
        }

        public async Task<List<BalanceInfo>> GetBalances()
        {
            var args = GeneratePayload("/v1/balances");
            return await Process<List<BalanceInfo>>(args);
        }

        public async Task<List<OrderInfo>> GetActiveOrders()
        {
            var args = GeneratePayload("/v1/orders");
            return await Process<List<OrderInfo>>(args);
        }

        public async Task<List<OrderInfo>> GetOrdersHistory()
        {
            var args = GeneratePayload("/v1/orders/hist");
            return await Process<List<OrderInfo>>(args);
        }

        public async Task<List<PositionInfo>> GetActivePositions()
        {
            var args = GeneratePayload("/v1/positions");
            return await Process<List<PositionInfo>>(args);
        }

        public async Task<OrderInfo> CreateOrder(
            string symbol,
            decimal amount,
            decimal price,
            OrderSide side,
            OrderType type)
        {
            var args = GeneratePayload("/v1/order/new");
            args.Add("exchange", "bitfinex");
            args.Add("symbol", symbol);
            args.Add("amount", amount.ToString());
            args.Add("price", price.ToString());
            args.Add("side", ConvertHelper.ObtainEnumValue(side));
            args.Add("type", ConvertHelper.ObtainEnumValue(type));

            return await Process<OrderInfo>(args);
        }

        public async Task<BaseInfo> CancelAllOrders()
        {
            var args = GeneratePayload("/v1/order/cancel/all");
            return await Process<BaseInfo>(args);
        }

        public async Task<BaseInfo> ClosePosition(long id)
        {
            var args = GeneratePayload("/v1/position/close");
            args.Add("position_id", id);

            return await Process<BaseInfo>(args);
        }
    }
}
