using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetFundingRateHistoryTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;
        List<FundingRateHistory> mp;

        [Test]
        public void GetFoundingRateHistoryWithDefaulLimitTest()
        {
            mp = market.GetFundingRateHistory("BTCUSDT");

            CheckResponse(100);
        }

        [Test]
        public void GetFoundingRateHistoryWithCustomLimitTest()

        {
            mp = market.GetFundingRateHistory("BTCUSDT", 20);

            CheckResponse(20);
        }

        void CheckResponse(int limit)
        {
            Assert.IsNotNull(mp);
            Assert.AreEqual("BTCUSDT", mp[0].Symbol);
            Assert.Greater(mp[0].FundingTime, 0);

            Assert.IsTrue(mp.Count > 0 && mp.Count <= limit);
        }
    }
}
