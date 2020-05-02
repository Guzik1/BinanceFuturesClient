using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class ChangePositionModeTests
    {
        GBinanceFuturesClient.Trade trade;

        [SetUp]
        public void OnSetup()
        {
            BinanceFuturesClient client = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            client.UseTestnet(true);
            trade = client.Trade;
        }

        [Test]
        public void ChangePostionModeTest()
        {
            try
            {
                bool result = trade.ChangePositionMode(true);
                Assert.IsTrue(result);
            }
            catch (ErrorMessageException e)
            {
                StringAssert.AreNotEqualIgnoringCase("", e.Message);   // Invalide api key (test api key on public api, not testnet).
                StringAssert.AreEqualIgnoringCase("API-key format invalid.", e.Message);
            }
        }
    }
}
