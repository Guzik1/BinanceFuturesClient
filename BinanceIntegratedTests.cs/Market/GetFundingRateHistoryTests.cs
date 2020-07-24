using GBinanceFuturesClient;
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
            try
            {
                mp = market.GetFundingRateHistory("BTCUSDT");

                CheckResponse(100);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetFoundingRateHistoryWithCustomLimitTest()
        {
            try
            {
                mp = market.GetFundingRateHistory("BTCUSDT", 20);

                CheckResponse(20);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        void CheckResponse(int limit)
        {
            try
            {
                Assert.IsNotNull(mp);
                Assert.AreEqual("BTCUSDT", mp[0].Symbol);
                Assert.Greater(mp[0].FundingTime, 0);

                Assert.IsTrue(mp.Count > 0 && mp.Count <= limit);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
