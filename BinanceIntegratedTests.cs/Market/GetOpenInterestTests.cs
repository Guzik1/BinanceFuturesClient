using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetOpenInterestTests
    {
        GBinanceFuturesClient.Market market;

        [SetUp]
        public void SetUp()
        {
            GBinanceFuturesClient.BinanceFuturesClient client = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            client.UseTestnet(true);
            market = client.Market;
        }

        [Test]
        public void GetOpenInterestTest()
        {
            try
            {
                OpenInterestItem oi = market.GetOpenInterest("BTCUSDT");

                Assert.IsNotNull(oi);
                Assert.Greater(oi.OpenInterest, 0);
                Assert.AreEqual("BTCUSDT", oi.Symbol);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
