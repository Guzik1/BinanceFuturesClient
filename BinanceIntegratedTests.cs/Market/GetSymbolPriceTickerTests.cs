using BinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetSymbolPriceTickerTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

        [Test]
        public void GetSingleSymbolPriceTest()
        {
            SymbolPriceTicker ticker = market.GetSymbolPriceTicker("BTCUSDT");

            Assert.IsNotNull(ticker);
            Assert.AreEqual("BTCUSDT", ticker.Symbol);
            Assert.Greater(ticker.Price, 0);
        }

        [Test]
        public void GetAllSymbolPriceTest()
        {
            List<SymbolPriceTicker> tickers = market.GetSymbolPriceTicker();

            Assert.IsNotNull(tickers);
            int index = tickers.FindIndex(n => n.Symbol == "BTCUSDT");
            Assert.AreNotEqual(-1, index);
        }
    }
}
