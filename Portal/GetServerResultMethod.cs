using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;


using BitfinexAPI;

/// <summary>
/// 这个类是用来嫁接原来的BitfinexAPI中的BitfinexMethod类的，将其中的方法进行改写
/// </summary>

namespace Portal
{
    static class ConvertHelper
    {
        public static string ObtainEnumValue<T>(T data)
        {
            var info = JsonConvert.SerializeObject(data, new StringEnumConverter());
            return JsonConvert.DeserializeObject<string>(info);
        }
    }


    public class GetServerResultMethod
    {
        string _apiKey;
        string _secretKey;

        public GetServerResultMethod(string apiKey, string secretKey)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
        }


        //没有任何参数的时候请求此函数，如果有参数，需要请求后面的参数
        async Task<T> ProcessPublic<T>(string path)
        {
            return await HttpCall.InvokeHttpCall<T>(path);
        }

        //若传递参数的话，则调用此函数
        async Task<T> ProcessAuthenticated<T>(BaseInfo args)
        {
            return await HttpCall.InvokeHttpCall<T>(
                (string)args["request"], args);
        }

        //
        public async Task<List<string>> GetSymbols()
        {
            return await ProcessPublic<List<string>>("GetSymbols");
        }

        //
        public async Task<TickerInfo> GetTicker(string symbol)
        {
            BaseInfo args = GeneratePayload("GetTicker");
            args.Add("symbol", symbol);
            return await ProcessAuthenticated<TickerInfo>(args);
            //return await ProcessPublic<TickerInfo>("/v1/pubticker/" + symbol.ToLower());
        }

        public async Task<List<TradeInfo>> GetTrades(string symbol)
        {
            BaseInfo args = GeneratePayload("GetTrades");
            args.Add("symbol", symbol);
            return await ProcessAuthenticated<List<TradeInfo>>(args);
            //return await ProcessPublic<List<TradeInfo>>("/v1/trades/" + symbol.ToLower());
        }

        public async Task<OrderBookInfo> GetOrderBook(string symbol)
        {
            BaseInfo args = GeneratePayload("GetOrderBook");
            args.Add("symbol", symbol);
            return await ProcessAuthenticated<OrderBookInfo>(args);
            //return await ProcessPublic<OrderBookInfo>("/v1/book/" + symbol.ToLower());
        }

        public async Task<List<BalanceInfo>> GetBalances()
        {
            var args = GeneratePayload("GetBalances");
            return await ProcessAuthenticated<List<BalanceInfo>>(args);
        }

        public async Task<List<OrderInfo>> GetActiveOrders()
        {
            var args = GeneratePayload("GetActiveOrders");
            return await ProcessAuthenticated<List<OrderInfo>>(args);
        }

        public async Task<List<OrderInfo>> GetOrdersHistory(int limit = 100)
        {
            BaseInfo args = GeneratePayload("GetOrdersHistory");
            args.Add("limit", limit);
            return await ProcessAuthenticated<List<OrderInfo>>(args);
        }

        public async Task<List<PositionInfo>> GetActivePositions()
        {
            BaseInfo args = GeneratePayload("GetActivePositions");
            return await ProcessAuthenticated<List<PositionInfo>>(args);
        }

        public async Task<List<TransactionInfo>> GetTradeRecords(string symbol)
        {
            var args = GeneratePayload("GetTradeRecords");
            args.Add("symbol", symbol.ToLower());

            return await ProcessAuthenticated<List<TransactionInfo>>(args);
        }

        public async Task<List<AssetMovementInfo>> GetAssetMovements(string currency)
        {
            var args = GeneratePayload("GetAssetMovements");
            args.Add("currency", currency.ToUpper());

            return await ProcessAuthenticated<List<AssetMovementInfo>>(args);
        }

        public async Task<List<BaseInfo>> TransferWallets(
            decimal amount,
            string currency,
            WalletType walletfrom,
            WalletType walletto)
        {
            var args = GeneratePayload("TransferWallets");
            args.Add("amount", amount.ToString());
            args.Add("currency", currency.ToUpper());
            args.Add("walletfrom", ConvertHelper.ObtainEnumValue(walletfrom));
            args.Add("walletto", ConvertHelper.ObtainEnumValue(walletto));

            return await ProcessAuthenticated<List<BaseInfo>>(args);
        }

        public async Task<OrderInfo> CreateOrder(
            string symbol,
            decimal amount,
            decimal price,
            OrderSide side,
            OrderType type)
        {
            var args = GeneratePayload("CreateOrder");
            args.Add("exchange", "bitfinex");
            args.Add("symbol", symbol.ToLower());
            args.Add("amount", amount.ToString());
            args.Add("price", price.ToString());
            args.Add("side", ConvertHelper.ObtainEnumValue(side));
            args.Add("type", ConvertHelper.ObtainEnumValue(type));

            return await ProcessAuthenticated<OrderInfo>(args);
        }

        public async Task<BaseInfo> CancelAllOrders()
        {
            var args = GeneratePayload("CancelAllOrders");
            return await ProcessAuthenticated<BaseInfo>(args);
        }

        public async Task<OrderInfo> CancelOrder(long id)
        {
            var args = GeneratePayload("CancelOrder");
            args.Add("id", id);
            return await ProcessAuthenticated<OrderInfo>(args);
        }

        public async Task<BaseInfo> ClosePosition(long id)
        {
            var args = GeneratePayload("ClosePosition");
            args.Add("id", id);

            return await ProcessAuthenticated<BaseInfo>(args);
        }


        //-------------------------------------需要慎重的两个函数------开始-------------------
        //
        public async Task<List<KlineInfo>> GetHistoryKlines(
            string symbol,
            KlineInterval interval,
            DateTime start,
            DateTime end,
            int limit = 800)
        {
            long s = new DateTimeOffset(start).ToUnixTimeMilliseconds();
            long e = new DateTimeOffset(end).ToUnixTimeMilliseconds();

            //string path = "/v2/candles/trade:"
            //    + ConvertHelper.ObtainEnumValue(interval)
            //    + ":t" + symbol.ToUpper()
            //    + "/hist?limit=" + limit.ToString()
            //    + "&start=" + s.ToString()
            //    + "&end=" + e.ToString()
            //    + "&sort=1";

            BaseInfo args = GeneratePayload("GetHistoryKlines");
            args.Add("symbol", symbol);
            args.Add("interval", ConvertHelper.ObtainEnumValue(interval));
            args.Add("start", s);
            args.Add("end", e);
            args.Add("limit", limit);

            return await ProcessAuthenticated<List<KlineInfo>>(args);
            //return await ProcessPublic<List<KlineInfo>>(path);
        }

        public async Task<List<TradeRecordInfo>> GetHistoryTrades(
            string symbol,
            DateTime start,
            DateTime end,
            int limit = 800)
        {
            long s = new DateTimeOffset(start).ToUnixTimeMilliseconds();
            long e = new DateTimeOffset(end).ToUnixTimeMilliseconds();

            string path = "/v2/trades/t" + symbol.ToUpper()
                + "/hist?limit=" + limit.ToString()
                + "&start=" + s.ToString()
                + "&end=" + e.ToString()
                + "&sort=1";

            return await ProcessPublic<List<TradeRecordInfo>>(path);
        }

        //---------------------------需要慎重的两个函数-----结束----------------------------


        BaseInfo GeneratePayload(string path)
        {
            path = "Bitfinex/" + path;
            var args = new BaseInfo();
            args.Add("request", path);
            args.Add("nonce", DateTime.Now.Ticks.ToString());

            return args;
        }



    }

}
