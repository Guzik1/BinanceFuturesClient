using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOrderBookPriceTickerTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetSingleOrderBookPriceTickerTest()
        {
            try
            {
                OrderBookTicker ticker = market.GetOrderBookTicker("BTCUSDT");

                Assert.IsNotNull(ticker);
                Assert.AreEqual("BTCUSDT", ticker.Symbol);
                Assert.Greater(ticker.AskPrice, 0);
                Assert.Greater(ticker.BidPrice, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetAllOrderBookPriceTickersTest()
        {
            try
            {
                List<OrderBookTicker> tickers = market.GetOrderBookTicker();

                Assert.IsNotNull(tickers);
                int index = tickers.FindIndex(n => n.Symbol == "BTCUSDT");
                Assert.AreNotEqual(-1, index);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
