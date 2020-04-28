using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class NewFundsTransferTests
    {
        GBinanceFuturesClient.Trade trade;

        [SetUp]
        public void SetUp()
        {
            BinanceFuturesClient client = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            trade = client.Trade;
        }

        [Test]
        public void NewFundsTransferTest()
        {
            try
            {
                string id = trade.NewFundsTransfer("USDT", 10, 1);

            }
            catch (ErrorMessageException e)
            {
                StringAssert.AreNotEqualIgnoringCase("", e.Message);   // Invalide api key (test api key on public api, not testnet).
                StringAssert.AreEqualIgnoringCase("Invalid Api-Key ID.", e.Message);
            }
        }
    }
}
