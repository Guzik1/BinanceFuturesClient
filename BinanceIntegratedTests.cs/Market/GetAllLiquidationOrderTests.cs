using BinanceFuturesClient.Model.Market;
using BinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetAllLiquidationOrderTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetLiquidationOrderTest()
        {
            List<LiquidationOrder> lo = market.GetLiquidationOrders("BTCUSDT", 10);

            Assert.IsNotNull(lo);
            Assert.AreEqual("BTCUSDT", lo[0].Symbol);
            Assert.Greater(lo[0].Time, 0);
            Assert.Greater(lo[0].Price, 0);
            Assert.AreEqual(lo.Count, 10);
        }

        [Test]
        public void GetLiquidationOrderWithCustomTimeTest()
        {
            List<LiquidationOrder> lo = market.GetLiquidationOrders(1587293244025, 1587295610552, "BTCUSDT", 10);

            Assert.IsNotNull(lo);
            Assert.AreEqual(5, lo.Count);
            Assert.AreEqual("BTCUSDT", lo[0].Symbol);
            Assert.Greater(lo[0].Time, 0);
            Assert.Greater(lo[0].Price, 0);
        }
    }
}
