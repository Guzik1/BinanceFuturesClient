using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOldTradeLookupListTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetOldTradeLookupListWithDefaultLimitTest()
        {
            List<TradeItem> trades = market.GetRectenTradesList("BTCUSDT");

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 500);
        }

        [Test]
        public void GetOldTradeLookupListWithCustomLimitTest()
        {
            List<TradeItem> trades = market.GetRectenTradesList("BTCUSDT", 200);

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 200);
        }
    }
}
