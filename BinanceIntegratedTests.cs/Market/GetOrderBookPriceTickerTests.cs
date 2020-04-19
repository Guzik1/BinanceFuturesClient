using BinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOrderBookPriceTickerTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetSingleOrderBookPriceTickerTest()
        {
            OrderBookTicker ticker = market.GetOrderBookTicker("BTCUSDT");

            Assert.IsNotNull(ticker);
            Assert.AreEqual("BTCUSDT", ticker.Symbol);
            Assert.Greater(ticker.AskPrice, 0);
            Assert.Greater(ticker.BidPrice, 0);
        }

        [Test]
        public void GetAllOrderBookPriceTickersTest()
        {
            List<OrderBookTicker> tickers = market.GetOrderBookTicker();

            Assert.IsNotNull(tickers);
            int index = tickers.FindIndex(n => n.Symbol == "BTCUSDT");
            Assert.AreNotEqual(-1, index);
        }
    }
}
