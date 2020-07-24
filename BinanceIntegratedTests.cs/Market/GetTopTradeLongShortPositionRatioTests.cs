using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetTopTradeLongShortPositionRatioTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Market;
        List<RatioItem> ois;

        [Test]
        public void GetTopTradeLongShortPositionTest()
        {
            try
            {
                ois = market.GetTopTradeLongShortPositionsRatio("BTCUSDT", "5m");

                Test();
                Assert.AreEqual(30, ois.Count);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetTopTradeLongShortPositionWithLimitTest()
        {
            try
            {
                ois = market.GetTopTradeLongShortPositionsRatio("BTCUSDT", "5m", 10);

                Test();
                Assert.AreEqual(10, ois.Count);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetTopTradeLongShortPositionCustomTimeTest()
        {
            try
            {
                ois = market.GetTopTradeLongShortPositionsRatio("BTCUSDT", "5m", Tools.NowUnixTimeMinusDays(-1), Tools.NowUnixTime());

                Test();
                Assert.Greater(ois.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
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
