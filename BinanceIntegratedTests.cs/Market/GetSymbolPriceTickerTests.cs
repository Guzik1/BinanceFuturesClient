using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetSymbolPriceTickerTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void GetSingleSymbolPriceTickerTest()
        {
            try
            {
                PriceTicker ticker = market.GetSymbolPriceTicker("BTCUSDT");

                Assert.IsNotNull(ticker);
                Assert.AreEqual("BTCUSDT", ticker.Symbol);
                Assert.Greater(ticker.Price, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetAllSymbolPricetickersTest()
        {
            try
            {
                List<PriceTicker> tickers = market.GetSymbolPriceTicker();

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
