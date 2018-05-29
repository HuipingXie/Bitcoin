using System;

namespace BitfinexAPI
{
    public class BitfinexStream
    {
        BaseInfo GeneratePayload(string type)
        {
            var args = new BaseInfo();
            args.Add("event", "subscribe");
            args.Add("channel", type);

            return args;
        }

        public BitfinexStream()
        {
        }

        public void RetrieveTrades(Action<PairInfo> handler, string symbol)
        {
            var args = GeneratePayload("trades");
            args.Add("pair", symbol.ToUpper());

            AccessWebSocket.Subscribe(args, o =>
            {
                if ((o.Count == 6) || (o.Count == 7))
                    handler(new PairInfo()
                    {
                        amount = (decimal)o[o.Count - 1],
                        price = (decimal)o[o.Count - 2],
                        timestamp = DateTimeOffset.FromUnixTimeSeconds((long)o[o.Count - 3]).DateTime,
                    });
            });
        }

        ~BitfinexStream()
        {
        }
    }
}
