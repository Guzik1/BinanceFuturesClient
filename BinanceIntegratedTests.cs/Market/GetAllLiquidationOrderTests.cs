using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetAllLiquidationOrderTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetLiquidationOrderTest()
        {
            try
            {
                List<LiquidationOrder> lo = market.GetLiquidationOrders("BTCUSDT", 10);

                Assert.IsNotNull(lo);
                Assert.AreEqual("BTCUSDT", lo[0].Symbol);
                Assert.Greater(lo[0].Time, 0);
                Assert.Greater(lo[0].Price, 0);
                Assert.AreEqual(lo.Count, 10);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetLiquidationOrderWithCustomTimeTest()
        {
            try
            {
                List<LiquidationOrder> lo = market.GetLiquidationOrders(1587293244025, 1587295610552, "BTCUSDT", 10);

                Assert.IsNotNull(lo);
                Assert.AreEqual(5, lo.Count);
                Assert.AreEqual("BTCUSDT", lo[0].Symbol);
                Assert.Greater(lo[0].Time, 0);
                Assert.Greater(lo[0].Price, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
