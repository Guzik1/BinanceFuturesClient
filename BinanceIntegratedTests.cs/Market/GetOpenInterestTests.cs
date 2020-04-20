using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOpenInterestTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetOpenInterestTest()
        {
            OpenInterestItem oi = market.GetOpenInterest("BTCUSDT");

            Assert.IsNotNull(oi);
            Assert.Greater(oi.OpenInterest, 0);
            Assert.AreEqual("BTCUSDT", oi.Symbol);
        }
    }
}
