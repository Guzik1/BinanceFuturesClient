﻿using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class Get24hTickerTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void Get24hAllTickersTest()
        {
            try
            {
                List<Ticker24h> tickers = market.Get24hTicker();

                Assert.IsNotNull(tickers);
                Assert.Greater(tickers.Count, 0);

                int index = tickers.FindIndex(n => n.Symbol == "BTCUSDT");
                Assert.AreNotEqual(-1, index);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void Get24hTickerTest()
        {
            try
            {
                Ticker24h ticker = market.Get24hTicker("BTCUSDT");

                Assert.IsNotNull(ticker);
                Assert.Greater(ticker.Count, 0);
                Assert.AreEqual("BTCUSDT", ticker.Symbol);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
