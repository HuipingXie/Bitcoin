using System;
using System.Collections.Generic;

using WebSocketSharp;

namespace BinanceAPI
{
    static class AccessWebSocket
    {
        const string endpointBase = "wss://stream.binance.com:9443/ws/";

        static Dictionary<int, WebSocket> _socketPool;
        static int _socketIdCounter;

        static AccessWebSocket()
        {
            _socketPool = new Dictionary<int, WebSocket>();
            _socketIdCounter = 0;
        }

        public static int Subscribe<T>(string args, Action<T> handler)
        {
            WebSocket ws = new WebSocket(endpointBase + args);

            ws.OnMessage += (sender, message) =>
            {
                handler(ConvertHelper.DataConvert<T>(message.Data));
            };

            ws.OnError += (sender, error) =>
            {
                throw new Exception("WebSocketException:" + typeof(T).FullName);
            };

            ws.Connect();

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
