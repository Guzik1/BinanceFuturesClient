using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetCandlesDataTests
    {
        GBinanceFuturesClient.Market market = new BinanceFuturesClient().Market;

        [Test]
        public void GetCandlesDataTest()
        {
            try
            {
                List<CandlestickData> trades = market.GetCandleStick("BTCUSDT", "30m");

                Assert.IsNotNull(trades);
                Assert.LessOrEqual(trades.Count, 500);
                Assert.Greater(trades[0].ClosePrice, 0);
                Assert.Greater(trades[0].LowPrice, 0);
                Assert.Greater(trades[0].BaseVolume, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
