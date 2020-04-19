using BinanceFuturesClient.Model.Market;
using BinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOpenInterestTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

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
