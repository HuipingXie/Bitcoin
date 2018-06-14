using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

//使用BinanceAPI和BitfinexAPI
using BitfinexAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using SqlUtility;

/// <summary>
/// 
///本文件中，未对接口超时加以处理，如果有后续需求，再进行改动
/// </summary>


namespace WebAPI.Controllers
{
    static class ConvertHelper
    {
        public static string ObtainEnumValue<T>(T data)
        {
            var info = JsonConvert.SerializeObject(data, new StringEnumConverter());
            return JsonConvert.DeserializeObject<string>(info);
        }
    }

    public class BitfinexController : Controller
    {
        //
        public static Queue<string> RequestQueenTime;

        //测试是否所有人都公用此变量;测试结果为所有人公用此变量
        //在实际程序中，此id需要在程序启动时从数据库中拿出
        public static int OrderHistoryId = 0;

        //将此变量设置为最近更新mysql的时间
        //public static int LastUpdateTime = 0;

        //将时间转成时间戳
        private static int GetTimeStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }

        public BitfinexMethod Bitfinex = new BitfinexMethod(ConfigurationManager.AppSettings["ApiKey"], ConfigurationManager.AppSettings["SecretKey"]);

        public BitfinexSqlOperation BitSqlOper = new BitfinexSqlOperation(
            ConfigurationManager.AppSettings["Server"],
            ConfigurationManager.AppSettings["User"],
            ConfigurationManager.AppSettings["Password"],
            ConfigurationManager.AppSettings["Database"],
            ConfigurationManager.AppSettings["Port"],
            ConfigurationManager.AppSettings["Charset"]
            );

        // GET: Order
        public string Index()
        {
            return "<h1>hello bitfinex</h1><br>last order id:" + OrderHistoryId;
        }

        public string Test()
        {
            OrderHistoryId += 10;
            return "order id 自增长10";
        }

        //获取symbols
        public async Task<string> GetSymbols()
        {
            var result = await Bitfinex.GetSymbols();
            return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> GetTicker(string symbol)
        {

            var result = await Bitfinex.GetTicker(symbol);
            return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> GetTrades(string symbol)
        {

            var result = await Bitfinex.GetTrades(symbol);
            return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> GetOrderBook(string symbol)
        {
            var result = await Bitfinex.GetOrderBook(symbol);
            return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> GetBalances()
        //public string GetBalances()
        {
            int timeStamp = GetTimeStamp(DateTime.Now);
            long lastUpdateTime = BitSqlOper.GetLastUpdateTime("balanceinfo");
            //如果上次更新时间超过60s，则直接调用接口
            if (timeStamp-lastUpdateTime>60)
            {
                var result = await Bitfinex.GetBalances();
                BitSqlOper.AddBalanceInfo(result);
                return JsonConvert.SerializeObject(result);

            }
            else
            {
                var result = BitSqlOper.GetBalanceInfos();
                return JsonConvert.SerializeObject(result);
            }

            //var result = await Bitfinex.GetBalances();
            //var res = BitSqlOper.GetBalanceInfos();
            //return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> GetActiveOrders()
        {
            var result = await Bitfinex.GetActiveOrders();

            return JsonConvert.SerializeObject(result);
        }

        //获取订单历史
        public async Task<string> GetOrdersHistory(int limit=100)
        //public string GetOrdersHistory(int limit = 100)
        {
            //此函数用到数据库，以数据库为缓存
            


            int timeStamp = GetTimeStamp(DateTime.Now);
            long lastUpdateTime = BitSqlOper.GetLastUpdateTime("orderinfo");

            if (timeStamp - lastUpdateTime > 60)
            {
                var result = await Bitfinex.GetOrdersHistory(limit);
                BitSqlOper.UpdateOrderHistory(result);
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = BitSqlOper.GetOrderHistory(limit);
                return JsonConvert.SerializeObject(result);
            }

        }



        //
        public async Task<string> GetActivePositions()
        //public string GetActivePositions()
        {
            var result = await Bitfinex.GetActivePositions();
            //var res = BitSqlOper.GetActivePositions();
            return JsonConvert.SerializeObject(result);
        }

        //获取交易记录
        public async Task<string> GetTradeRecords(string symbol)
        {
            var result = await Bitfinex.GetTradeRecords(symbol);
            return JsonConvert.SerializeObject(result);

        }


        //
        public async Task<string> GetAssetMovements(string currency)
        {
            var result = await Bitfinex.GetAssetMovements(currency);
            return JsonConvert.SerializeObject(result);

        }

        //
        public async Task<string> TransferWallets(decimal amount, string currency, string walletfrom, string walletto)
        {


            WalletType formatedWalletfrom = (WalletType)Enum.Parse(typeof(WalletType), walletfrom);
            WalletType formatedWalletto = (WalletType)Enum.Parse(typeof(WalletType), walletto);
            var result = await Bitfinex.TransferWallets(amount, currency, formatedWalletfrom, formatedWalletto);
            return JsonConvert.SerializeObject(result);
        }

        //创建订单
        public async Task<string> CreateOrder(string symbol, decimal amount, decimal price, string side, string type)
        {

            //var Bitfinex = new BitfinexMethod(this.apiKey, this.secertKey);
            OrderSide formatedSide = (OrderSide)Enum.Parse(typeof(OrderSide), side.ToUpper());
            OrderType formatedType = (OrderType)Enum.Parse(typeof(OrderType), type.ToUpper());

            var result = await Bitfinex.CreateOrder(symbol, amount, price, formatedSide, formatedType);

            //var resStr = "symbol:"+symbol.ToString()+"amount:"+amount.ToString()+"price:"+price.ToString();
            //return resStr;

            return JsonConvert.SerializeObject(result);
        }


        //取消所有订单,emmmm,感觉这个接口有风险啊
        public async Task<string> CancelAllOrders()
        {
            var result = await Bitfinex.CancelAllOrders();
            return JsonConvert.SerializeObject(result);

        }


        //根据订单的编号取消订单
        public async Task<string> CancelOrder(long id)
        {
            var result = await Bitfinex.CancelOrder(id);
            return JsonConvert.SerializeObject(result);
        }

        //
        public async Task<string> ClosePosition(long id)
        {

            var result = await Bitfinex.ClosePosition(id);
            return JsonConvert.SerializeObject(result);
        }


        //
        public async Task<string> GetHistoryKlines(string symbol, string interval, DateTime start, DateTime end,
            int limit = 800)
        {
            //经过测试，此处string类型的start的DateTime类型可以直接转成DateTime类型，故可忽略
            //此处需要和客户端进行沟通,找到使用的地方，沟通时间的表示形式，以时间戳还是以字符串表示
            //此处的时间为DateTime类型的变量直接调用toString()方法得到的，形如：“2018/6/8 16:02:57”


            BitfinexAPI.KlineInterval formatedInterval = (BitfinexAPI.KlineInterval)Enum.Parse(typeof(BitfinexAPI.KlineInterval), interval);


            var Result = await Bitfinex.GetHistoryKlines(symbol, formatedInterval, start, end);

            return JsonConvert.SerializeObject(Result);

        }


        //
        public async Task<string> GetHistoryTrades(string symbol, DateTime start, DateTime end, int limit = 800)
        {

            //经过测试，此处string类型的start的DateTime类型可以直接转成DateTime类型，故可忽略
            //此处需要和客户端进行沟通,找到使用的地方，沟通时间的表示形式，以时间戳还是以字符串表示
            //此处的时间为DateTime类型的变量直接调用toString()方法得到的，形如：“2018/6/8 16:02:57”

            var Result = await Bitfinex.GetHistoryTrades(symbol, start, end, limit);
            return JsonConvert.SerializeObject(Result);
        }



    }
}