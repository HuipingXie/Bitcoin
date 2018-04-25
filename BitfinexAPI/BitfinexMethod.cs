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

        public async Task<List<TradeInfo>> GetTrades(string symbol)
        {
            string path = "/v1/trades/" + symbol;
            return await AccessRestApi.InvokePublicCall<List<TradeInfo>>(path);
        }

        public async Task<OrderBookInfo> GetOrderBook(string symbol)
        {
            string path = "/v1/book/" + symbol;
            return await AccessRestApi.InvokePublicCall<OrderBookInfo>(path);
        }

        public async Task<List<BalanceInfo>> GetBalances()
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/balances");
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return await AccessRestApi.InvokeAuthenticatedCall<List<BalanceInfo>>(
                args, _apiKey, _secretKey);
        }

        public async Task<List<OrderInfo>> GetActiveOrders()
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/orders");
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return await AccessRestApi.InvokeAuthenticatedCall<List<OrderInfo>>(
                args, _apiKey, _secretKey);
        }

        public async Task<List<OrderInfo>> GetOrdersHistory()
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/orders/hist");
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return await AccessRestApi.InvokeAuthenticatedCall<List<OrderInfo>>(
                args, _apiKey, _secretKey);
        }

        public async Task<List<PositionInfo>> GetActivePositions()
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/positions");
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return await AccessRestApi.InvokeAuthenticatedCall<List<PositionInfo>>(
                args, _apiKey, _secretKey);
        }

        public async Task<OrderInfo> CreateOrder(
            string symbol,
            decimal amount,
            decimal price,
            string side,
            string type)
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/order/new");
            args.Add("nonce", DateTime.Now.Ticks.ToString());
            args.Add("exchange", "bitfinex");
            args.Add("symbol", symbol);
            args.Add("amount", amount.ToString());
            args.Add("price", price.ToString());
            args.Add("side", side);
            args.Add("type", type);

            return await AccessRestApi.InvokeAuthenticatedCall<OrderInfo>(
                args, _apiKey, _secretKey);
        }

        public async Task<BaseInfo> CancelAllOrders()
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/order/cancel/all");
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return await AccessRestApi.InvokeAuthenticatedCall<BaseInfo>(
                args, _apiKey, _secretKey);
        }

        public async Task<BaseInfo> ClosePosition(long id)
        {
            BaseInfo args = new BaseInfo();
            args.Add("request", "/v1/position/close");
            args.Add("nonce", DateTime.Now.Ticks.ToString());
            args.Add("position_id", id);

            return await AccessRestApi.InvokeAuthenticatedCall<BaseInfo>(
                args, _apiKey, _secretKey);
        }
    }
}
