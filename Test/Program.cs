using System;
using BinanceAPI;

namespace Test
{
    class Program
    {
        const string apiKey = "MLWYRyvxqdAn3KnjLMIrcgibLQayZcrKg0ULzu4PHx1jbG72jvhRyNvs8GTL87Ii";
        const string secretKey = "4b5sRs2r9hzlcehgV4frFFhgjbAFanUZtMTpJqGFPUpwxjDSFu6aSWQhTNPwcqPo";

        const string symbol = "BtcUsdt";

        static void Main(string[] args)
        {
            BinanceMethod m = new BinanceMethod(symbol, apiKey, secretKey);
            var r = m.GetKlines(DateTime.UtcNow.AddDays(-2), DateTime.UtcNow.AddDays(-1), KlineInterval.OneMinute).Result;

            Console.ReadKey();
        }
    }
}
