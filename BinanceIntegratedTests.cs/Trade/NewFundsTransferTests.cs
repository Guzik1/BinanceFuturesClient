using GBinanceFuturesClient.Model.Market;
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
            GBinanceFuturesClient.BinanceFuturesClient client = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            trade = client.Trade;
        }

        [Test]
        public void NewFundsTransferTest()
        {
            string id = trade.NewFundsTransfer("USDT", 10, 1);
  
            StringAssert.AreNotEqualIgnoringCase("", id);
        }
    }
}
