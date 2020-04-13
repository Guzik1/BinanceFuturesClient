using BinanceFuturesClient.Model.Market;
using BinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOldTradeLookupListTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

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
