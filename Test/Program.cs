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

            BitfinexStream bs = new BitfinexStream();

            bs.RetrieveTrades(e => {
                Console.WriteLine(e.price + "  " + e.amount + "  " + e.timestamp);
            }, "eosusd");   

            Console.ReadKey();
        }
    }
}
