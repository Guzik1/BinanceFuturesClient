using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOpenInterestStatisticsTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Market;
        List<OpenInterestStatistics> ois;

        [Test]
        public void GetOpenInterestStatisticTest()
        {
            ois = market.GetOpenInterestStatistics("BTCUSDT", "5m");
            
            Test();
            Assert.AreEqual(30, ois.Count);
        }

        [Test]
        public void GetOpenInterestStatisticWithLimitTest()
        {
            ois = market.GetOpenInterestStatistics("BTCUSDT", "5m", 10);

            Test();
            Assert.AreEqual(10, ois.Count);
        }

        [Test]
        public void GetOpenInterestStatisticCustomTimeTest()
        {
            ois = market.GetOpenInterestStatistics("BTCUSDT", "5m", 1587408856829, 1587409956829);

            Test();
            Assert.Greater(ois.Count, 0);
        }

        void Test()
        {
            Assert.IsNotNull(ois);
            Assert.AreEqual("BTCUSDT", ois[0].Symbol);
            Assert.Greater(ois[0].SumOpenInterest, 0);
            Assert.Greater(ois[0].SumOpenInterestValue, 0);
        }
    }
}
