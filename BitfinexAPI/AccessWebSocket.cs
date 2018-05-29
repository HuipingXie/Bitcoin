using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace BitfinexAPI
{
    static class AccessWebSocket
    {
        const string Endpoint = "wss://api.bitfinex.com/ws";

        static Dictionary<int, WebSocket> _socketPool;
        static int _socketIdCounter;

        static AccessWebSocket()
        {
            _socketPool = new Dictionary<int, WebSocket>();
            _socketIdCounter = 0;
        }

        public static int Subscribe(BaseInfo args, Action<JArray> handler)
        {
            WebSocket ws = new WebSocket(Endpoint);
            //ws.SetProxy("http://localhost:1080", null, null);

            ws.OnMessage += (sender, message) =>
            {
                var data = JsonConvert.DeserializeObject(message.Data);

                if (data is JArray)
                    handler((JArray)data);
            };

            ws.OnError += (sender, error) =>
            {
                throw new Exception("WebSocketException:" + error.Message);
            };

            ws.Connect();

            ws.Send(JsonConvert.SerializeObject(args));

            _socketPool.Add(++_socketIdCounter, ws);
            return _socketIdCounter;
        }

        public static void Unsubscribe(int socketId)
        {
            _socketPool[socketId].Close();
            _socketPool.Remove(socketId);
        }
    }
}
