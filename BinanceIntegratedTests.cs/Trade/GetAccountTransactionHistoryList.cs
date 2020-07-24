using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class GetAccountTransactionHistoryList
    {
        [Test]
        public void GetAccountTransactionHistoryListTest()
        {
            GBinanceFuturesClient.Trade trade = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Trade;

            try
            {
                trade.GetAccountTransactionHistory("USDT", 1588362716945);
            }
            catch (ErrorMessageException e)
            {
                StringAssert.AreNotEqualIgnoringCase("", e.Message);   // Invalide api key (test api key on public api, not testnet, unavailable in testnet).
                StringAssert.AreEqualIgnoringCase("Invalid Api-Key ID.", e.Message);
            }
        }
    }
}
