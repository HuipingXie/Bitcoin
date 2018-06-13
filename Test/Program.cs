using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;

using BitfinexAPI;


using WebSocketSharp;
using Newtonsoft.Json;
using Portal;
using System.Threading.Tasks;
using SqlUtility;


namespace Test
{
    class Res
    {
        public int code;
        public string text;
        public Res(int code, string text)
        {
            this.code = code;
            this.text = text;
        }
        public override string ToString()
        {
            return this.code.ToString() + "\t" + this.code.ToString();
        }
    }
    class NewsInfo
    {
        public int news_id;
        public int user_id;
        public string content;
        public NewsInfo(int news_id, int user_id, string content)
        {
            this.news_id = news_id;
            this.user_id = user_id;
            this.content = content;
        }
        public override string ToString()
        {
            return this.news_id.ToString() + "\t" + this.user_id.ToString();
        }
    }

    class Program
    {

        //测试泛型
        public static void Fanxing<T>(List<T> objList)
        {
            foreach (var obj in objList)
            {
                Console.WriteLine(obj.ToString());
            }

        }

        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string w = "world";
            Console.WriteLine(String.Format("hello {0}!!", w));
            List<int> listint = new List<int>();
            listint.Add(1);
            listint.Add(2);
            listint.Add(3);
            listint.Add(4);
            listint.Add(5);
            listint.Add(6);
            listint.Add(7);
            List<Res> listRes = new List<Res>();
            List<NewsInfo> listNews = new List<NewsInfo>();
            foreach (int i in listint)
            {
                listRes.Add(new Res(i, (i * 10).ToString()));
                listNews.Add(new NewsInfo(i, i * 2, (i * 5).ToString()));
            }


            Fanxing<Res>(listRes);

            Console.WriteLine("--------------------------------");
            Fanxing<NewsInfo>(listNews);


            Console.ReadKey();
            BitfinexSqlOperation bso = new BitfinexSqlOperation();
            
            var orderlist = bso.getActiveOrderInfo(10);
            foreach (var item in orderlist)
            {
                Console.WriteLine(item.symbol + "\t" + item.price.ToString() + "\t" + item.id.ToString());
            }

            



            Console.ReadKey();


            /*
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            string secretKey = ConfigurationManager.AppSettings["SecretKey"];

            //BitfinexMethod bm = new BitfinexMethod(apiKey, secretKey);
            GetServerResultMethod gsm = new GetServerResultMethod(apiKey,secretKey);

            //BitfinexStream bs = new BitfinexStream();

            //bs.RetrieveTrades(e => {
            //    Console.WriteLine(e.price + "  " + e.amount + "  " + e.timestamp);
            //}, "eosusd");   

            //List<OrderInfo> res = bm.GetOrdersHistory(150).Result;
            Console.WriteLine("等待10秒......");
            Thread.Sleep(10000);
            //List<OrderInfo> res = bm.GetOrdersHistory(150).Result;
            List<OrderInfo> res = gsm.GetOrdersHistory(150).Result;
            //Console.WriteLine();
            int resLength = 0;
            foreach (var item in res)
            {
                resLength++;
                Console.WriteLine(item.id);
            }
            Console.WriteLine("等待2秒");
            Thread.Sleep(2000);

            string symbol = "EOSUSD";
            decimal amount = decimal.Parse("0.01");
            decimal price = decimal.Parse("12");
            OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide),"SELL");
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), "limit");

            var result =gsm.CreateOrder(symbol, amount, price, side, type).Result;
            Console.WriteLine(result.ToString());
            Console.WriteLine(resLength);
            Console.ReadKey();
            */
        }



    }
}
