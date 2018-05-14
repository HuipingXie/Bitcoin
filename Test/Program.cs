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

            DateTime start = DateTime.Now.AddDays(-150);
            DateTime end = start.AddMinutes(10);

            long s = new DateTimeOffset(start).ToUnixTimeMilliseconds();
            long e = new DateTimeOffset(end).ToUnixTimeMilliseconds();

            HttpClient hc = new HttpClient();
            var r = hc.GetAsync(
                "https://api.bitfinex.com/v2/trades/tEOSUSD/hist?start="
                + s + "&end=" + e +"&sort=1"+"&limit=1000").Result;

            string data = r.Content.ReadAsStringAsync().Result;
            List<List<decimal>> value = JsonConvert.DeserializeObject<List<List<decimal>>>(data);

            foreach (var i in value)
            {
                DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds((long)i[1]).DateTime;
                Console.WriteLine(dt + "  " + i[2] + "  " + i[3]);
            }

            Console.ReadKey();
        }
    }
}
