using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class PositionModeTests
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
        public void GetCurrentPositionModeTest()
        {
            try
            {
                bool result = trade.GetCurrentPositionMode();
                Assert.IsTrue(true);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        /*[Test]
        public void ChangePostionModeTest()
        {
            try
            {
                bool result = trade.ChangePositionMode(false);
                Assert.IsTrue(result);

                result = trade.GetCurrentPositionMode();
                Assert.IsTrue(result);

                result = trade.ChangePositionMode(false);
                Assert.IsTrue(result);

                result = trade.GetCurrentPositionMode();
                Assert.IsFalse(result);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }*/
    }
}
