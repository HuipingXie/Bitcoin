using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

using BitfinexAPI;
using BinanceAPI;

using WebSocketSharp;
using Newtonsoft.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            string secretKey = ConfigurationManager.AppSettings["SecretKey"];

            //BitfinexMethod bm = new BitfinexMethod(apiKey, secretKey);

            WebSocket ws = new WebSocket("wss://api.bitfinex.com/ws/");
            ws.SetProxy("http://localhost:1080", null, null);

            ws.OnMessage += (o, e) =>
            {
                Console.WriteLine(e.Data);
            };

            ws.Connect();
            Console.ReadKey();

            BaseInfo req = new BaseInfo();
            req.Add("event", "subscribe");
            req.Add("channel", "trades");
            req.Add("pair", "BTCUSD");

            ws.Send(JsonConvert.SerializeObject(req));

            Console.ReadKey();

            BaseInfo req2 = new BaseInfo();
            req2.Add("event", "subscribe");
            req2.Add("channel", "book");
            req2.Add("pair", "BTCUSD");
            req2.Add("prec", "P2");

            ws.Send(JsonConvert.SerializeObject(req2));

            Console.ReadKey();
            ws.Close();
        }
    }
}
