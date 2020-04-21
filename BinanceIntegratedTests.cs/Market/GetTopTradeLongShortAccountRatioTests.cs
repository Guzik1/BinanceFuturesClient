using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetTopTradeLongShortAccountRatioTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Market;
        List<RatioItem> ois;

        [Test]
        public void GetTopTradeLongShortRatioTest()
        {
            ois = market.GetTopTradeLongShortAccountsRatio("BTCUSDT", "5m");
            
            Test();
            Assert.AreEqual(30, ois.Count);
        }

        [Test]
        public void GetTopTradeLongShortRatioWithLimitTest()
        {
            ois = market.GetTopTradeLongShortAccountsRatio("BTCUSDT", "5m", 10);

            Test();
            Assert.AreEqual(10, ois.Count);
        }

        [Test]
        public void GetTopTradeLongShortRatioCustomTimeTest()
        {
            ois = market.GetTopTradeLongShortAccountsRatio("BTCUSDT", "5m", 1587408856829, 1587409956829);

            Test();
            Assert.Greater(ois.Count, 0);
        }

        void Test()
        {
            Assert.IsNotNull(ois);
            Assert.AreEqual("BTCUSDT", ois[0].Symbol);
            Assert.Greater(ois[0].LongAccount, 0);
            Assert.Greater(ois[0].LongShortRatio, 0);
            Assert.Greater(ois[0].ShortAccount, 0);
            Assert.Greater(ois[0].Timestamp, 0);
        }
    }
}
