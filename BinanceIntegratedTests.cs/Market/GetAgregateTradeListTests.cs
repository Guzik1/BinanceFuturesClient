using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetAgregateTradeListTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetOldTradeLookupListWithDefaultLimitTest()
        {
            try
            {
                List<AggregateTradeItem> trades = market.GetAggregateTradeList("BTCUSDT");

                Assert.IsNotNull(trades);
                Assert.LessOrEqual(trades.Count, 500);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetOldTradeLookupListWithCustomLimitTest()
        {
            try
            {
                List<AggregateTradeItem> trades = market.GetAggregateTradeList("BTCUSDT", 200);

                Assert.IsNotNull(trades);
                Assert.LessOrEqual(trades.Count, 200);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
