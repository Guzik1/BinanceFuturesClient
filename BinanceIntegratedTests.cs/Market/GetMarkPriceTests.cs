using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetMarkPriceTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetMarkPriceForOneMarketTest()
        {
            try
            {
                MarkPriceResponse mp = market.GetMarkPrice("BTCUSDT");

                Assert.IsNotNull(mp);
                Assert.AreEqual("BTCUSDT", mp.Symbol);
                Assert.Greater(mp.Time, 0);
                Assert.Greater(mp.MarkPrice, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetAllMarkPriceTest()
        {
            try
            {
                List<MarkPriceResponse> mp = market.GetMarkPrice();

                Assert.IsNotNull(mp);
                Assert.Greater(mp.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
