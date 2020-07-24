using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class ExchangeInfoTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetExchangeInfoTest()
        {
            try
            {
                ExchangeInfo ei = market.GetExchangeInfo();

                Assert.IsNotNull(ei);
                Assert.IsNotNull(ei.RateLimits);
                Assert.Greater(ei.ServerTime, 0);
                Assert.IsNotNull(ei.Symbols);
                Assert.Greater(ei.Symbols.Count, 0);

                int index = ei.Symbols.FindIndex(n => n.Symbol == "BTCUSDT");

                Assert.AreNotEqual(-1, index);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
