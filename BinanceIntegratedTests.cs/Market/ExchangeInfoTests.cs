using BinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class ExchangeInfoTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetExchangeInfoTest()
        {
            ExchangeInfo ei = market.GetExchangeInfo();

            Assert.IsNotNull(ei);
            Assert.IsNotNull(ei.RateLimits);
            Assert.Greater(ei.ServerTime, 0);
            Assert.IsNotNull(ei.Symbols);
            Assert.Greater(ei.Symbols.Count, 0);

            int index = ei.Symbols.FindIndex(n => n.Symbol == "BTCUSDT");

            Assert.AreNotEqual(-1, index);
        }
    }
}
