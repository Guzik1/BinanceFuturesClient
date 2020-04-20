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
            List<AggregateTradeItem> trades = market.GetAggregateTradeList("BTCUSDT");

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 500);
        }

        [Test]
        public void GetOldTradeLookupListWithCustomLimitTest()
        {
            List<AggregateTradeItem> trades = market.GetAggregateTradeList("BTCUSDT", 200);

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 200);
        }
    }
}
