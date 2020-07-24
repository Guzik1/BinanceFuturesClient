using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetBuySellVolumeTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Market;
        List<BuySellVolume> ois;

        [Test]
        public void GetBuySellVolumeTest()
        {
            try
            {
                ois = market.GetTakerBuySellVolume("BTCUSDT", "5m");

                Test();
                Assert.AreEqual(30, ois.Count);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetBuySellVolumeWithLimitTest()
        {
            try
            {
                ois = market.GetTakerBuySellVolume("BTCUSDT", "5m", 10);

                Test();
                Assert.AreEqual(10, ois.Count);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetBuySellVolumeCustomTimeTest()
        {
            try
            {
                ois = market.GetTakerBuySellVolume("BTCUSDT", "5m", Tools.NowUnixTimeMinusDays(-1), Tools.NowUnixTime());

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
            Assert.Greater(ois[0].BuySellRatio, 0);
            Assert.Greater(ois[0].BuyVol, 0);
            Assert.Greater(ois[0].SellVol, 0);
            Assert.Greater(ois[0].Timestamp, 0);
        }
    }
}
