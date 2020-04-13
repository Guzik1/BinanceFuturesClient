using BinanceFuturesClient.Model.Market;
using BinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetMarkPriceTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetMarkPriceForOneMarketTest()
        {
            MarkPriceResponse mp = market.GetMarkPrice("BTCUSDT");

            Assert.IsNotNull(mp);
            Assert.AreEqual("BTCUSDT", mp.Symbol);
            Assert.Greater(mp.Time, 0);
            Assert.Greater(mp.MarkPrice, 0);
        }

        [Test]
        public void GetAllMarkPriceTest()
        {
            List<MarkPriceResponse> mp = market.GetMarkPrice();

            Assert.IsNotNull(mp);
            Assert.Greater(mp.Count, 0);
        }
    }
}
