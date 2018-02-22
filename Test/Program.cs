using System;
using BinanceAPI;

namespace Test
{
    class Program
    {
        // fill the keys of your own account
        const string apiKey = "";
        const string secretKey = "";

        const string symbol = "BtcUsdt";

        static void Main(string[] args)
        {
            BinanceMethod m = new BinanceMethod(symbol, apiKey, secretKey);
            var r = m.GetKlines(DateTime.UtcNow.AddDays(-2), DateTime.UtcNow.AddDays(-1), KlineInterval.OneMinute).Result;

            Console.ReadKey();
        }
    }
}
