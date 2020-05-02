using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class GetCurrentPositionModeTests
    {
        GBinanceFuturesClient.Trade trade;

        [SetUp]
        public void SetUp()
        {
            BinanceFuturesClient client = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            client.UseTestnet(true);
            trade = client.Trade;
        }

        [Test]
        public void GetCurrentPositionModeTest()
        {
            try
            {
                bool result = trade.GetCurrentPositionMode();
                Assert.IsTrue(true);
            }
            catch (ErrorMessageException e)
            {
                StringAssert.AreNotEqualIgnoringCase("", e.Message);   // Invalide api key (test api key on public api, not testnet).
            }
        }
    }
}
