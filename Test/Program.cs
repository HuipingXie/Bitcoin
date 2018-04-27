using System;
using System.Configuration;

using BitfinexAPI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            string secretKey = ConfigurationManager.AppSettings["SecretKey"];

            BitfinexMethod m = new BitfinexMethod(apiKey, secretKey);
            var r = m.GetBalances().Result;

            Console.ReadKey();
        }
    }
}
