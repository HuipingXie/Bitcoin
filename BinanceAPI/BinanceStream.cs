using System;

namespace BinanceAPI
{
    public class BinanceStream
    {
        string _symbol;

        int? _klineSocketId;
        int? _tradeSocketId;
        int? _partialDepthSocketId;

        public BinanceStream(string symbol)
        {
            _symbol = symbol.ToLower();

            _klineSocketId = null;
            _tradeSocketId = null;
            _partialDepthSocketId = null;
        }

        public void RetrieveKline(Action<CurrentKlineInfo> handler, KlineInterval interval)
        {
            if (_klineSocketId.HasValue)
                AbortKline();

            _klineSocketId = AccessWebSocket.Subscribe(
                _symbol + "@kline_" + ConvertHelper.ObtainEnumValue(interval), handler);
        }

        public void AbortKline()
        {
            if (_klineSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_klineSocketId.Value);

            _klineSocketId = null;
        }

        public void RetrieveTrade(Action<TradeInfo> handler)
        {
            if (_tradeSocketId.HasValue)
                AbortTrade();

            _tradeSocketId = AccessWebSocket.Subscribe(
                _symbol + "@trade", handler);
        }

        public void AbortTrade()
        {
            if (_tradeSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_tradeSocketId.Value);

            _tradeSocketId = null;
        }

        public void RetrievePartialDepth(Action<OrderBookInfo> handler, int level)
        {
            if (_partialDepthSocketId.HasValue)
                AbortPartialDepth();

            _partialDepthSocketId = AccessWebSocket.Subscribe(
                _symbol + "@depth" + level.ToString(), handler);
        }

        public void AbortPartialDepth()
        {
            if (_partialDepthSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_partialDepthSocketId.Value);

            _partialDepthSocketId = null;
        }

        ~BinanceStream()
        {
            if (_tradeSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_tradeSocketId.Value);

            if (_partialDepthSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_partialDepthSocketId.Value);

            if (_klineSocketId.HasValue)
                AccessWebSocket.Unsubscribe(_klineSocketId.Value);
        }
    }
}
