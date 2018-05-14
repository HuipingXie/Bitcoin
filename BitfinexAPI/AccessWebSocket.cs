using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using WebSocketSharp;

namespace BitfinexAPI
{
    static class AccessWebSocket
    {
        const string endpointBase = "wss://api.bitfinex.com/ws";

        static Dictionary<string, WebSocket> _socketPool;

        static AccessWebSocket()
        {
            _socketPool = new Dictionary<string, WebSocket>();
        }

        public static string Subscribe<T>(string args, Action<T> handler)
        {
            WebSocket ws = new WebSocket(endpointBase + args);

            ws.OnMessage += (sender, message) =>
            {
                //handler();
            };

            ws.OnError += (sender, error) =>
            {
                throw new Exception("WebSocketException:" + typeof(T).FullName);
            };

            ws.Connect();
            ws.Send(args);

            string chanId = "";
            _socketPool.Add(chanId, ws);

            return chanId;
        }

        public static void Unsubscribe(string chanId)
        {
            _socketPool[chanId].Close();
            _socketPool.Remove(chanId);
        }
    }
}
