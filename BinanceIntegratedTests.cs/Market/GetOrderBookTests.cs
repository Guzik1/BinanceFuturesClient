using BinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOrderBookTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetOrderBookWithDefaultLimitTest()
        {
            OrderBook ob = market.GetOrderBook("BTCUSDT");

            Assert.IsNotNull(ob);
            Assert.LessOrEqual(ob.Bids.Count, 500);
            Assert.LessOrEqual(ob.Asks.Count, 500);
            Assert.Greater(ob.Bids.Count, 0);
            Assert.Greater(ob.Asks.Count, 0);
        }

        [Test]
        public void GetOrderBookWithCustomLimitTest()
        {
            OrderBook ob = market.GetOrderBook("BTCUSDT", 10);

            Assert.IsNotNull(ob);
            Assert.LessOrEqual(ob.Bids.Count, 10);
            Assert.LessOrEqual(ob.Asks.Count, 10);
            Assert.Greater(ob.Bids.Count, 0);
            Assert.Greater(ob.Asks.Count, 0);
        }
    }
}
