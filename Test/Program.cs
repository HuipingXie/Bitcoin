using System;
using BitfinexAPI;

namespace Test
{
    class Program
    {
        // fill the keys of your own account


        const string symbol = "BtcUsd";

        static void Main(string[] args)
        {
            BitfinexMethod m = new BitfinexMethod(apiKey, secretKey);
            var r = m.GetBalances().Result;

            Console.ReadKey();
        }
    }
}
