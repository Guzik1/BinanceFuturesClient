using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetRecentTradeListTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetRecentTradeListWithDefaultLimitTest()
        {
            List<TradeItem> trades = market.GetRectenTradesList("BTCUSDT");

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 500);
        }

        [Test]
        public void GetRecentTradeListWithCustomLimitTest()
        {
            List<TradeItem> trades = market.GetRectenTradesList("BTCUSDT", 200);

            Assert.IsNotNull(trades);
            Assert.LessOrEqual(trades.Count, 200);
        }
    }
}
