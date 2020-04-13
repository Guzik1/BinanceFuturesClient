using BinanceFuturesClient.Model.Market;
using BinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetRecentTradeListTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

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
