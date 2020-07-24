using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOrderBookTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;
        
        [Test]
        public void GetOrderBookWithDefaultLimitTest()
        {
            try
            {
                OrderBook ob = market.GetOrderBook("BTCUSDT");

                Assert.IsNotNull(ob);
                Assert.LessOrEqual(ob.Bids.Count, 500);
                Assert.LessOrEqual(ob.Asks.Count, 500);
                Assert.Greater(ob.Bids.Count, 0);
                Assert.Greater(ob.Asks.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetOrderBookWithCustomLimitTest()
        {
            try
            {
                OrderBook ob = market.GetOrderBook("BTCUSDT", 10);

                Assert.IsNotNull(ob);
                Assert.LessOrEqual(ob.Bids.Count, 10);
                Assert.LessOrEqual(ob.Asks.Count, 10);
                Assert.Greater(ob.Bids.Count, 0);
                Assert.Greater(ob.Asks.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
