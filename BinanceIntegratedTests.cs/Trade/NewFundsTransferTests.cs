﻿using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class NewFundsTransferTests
    {
        /* Already unavailable in futures api.
        [Test]
        public void NewFundsTransferTest()
        {
            GBinanceFuturesClient.Trade trade = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Trade;

            try
            {
                trade.NewFundsTransfer("USDT", 10, 1);

            }
            catch (ErrorMessageException e)
            {
                StringAssert.AreNotEqualIgnoringCase("", e.Message);   // Invalide api key (test api key on public api, not testnet).
                StringAssert.AreEqualIgnoringCase("Invalid Api-Key ID.", e.Message);
                //Assert.Fail();
            }
        }

        [Test]
        public void UnautorizeUserTest()
        {
            GBinanceFuturesClient.Trade trade = new BinanceFuturesClient().Trade;

            try
            {
                string id = trade.NewFundsTransfer("USDT", 10, 1);
                Assert.Fail();
            }
            catch (ErrorMessageException e) { 
                Assert.Fail(e.Message); 
            }
            catch (Exception) // TODO: change this exception to unautorize user exception.
            {
                Assert.IsTrue(true);
            }
        }*/
    }
}
