using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Trade;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class GetNationalBracketsTests
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
        public void GetNationalBracketsForOneMarketTest()
        {
            SetUp();
            NationalAndLeverageBrackets nlb;

            try
            {
                nlb = trade.GetNationalBrackets("BTCUSDT");

                Assert.IsNotNull(nlb);
                Assert.AreEqual("BTCUSDT", nlb.Symbol);
                Assert.Greater(nlb.Brackets.Count, 0);
            }
            catch(ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetAllNationalBracketsTest()
        {
            SetUp();
            List<NationalAndLeverageBrackets> nlb = new List<NationalAndLeverageBrackets>();

            try
            {
                nlb = trade.GetNationalBrackets();

                Assert.IsNotNull(nlb);
                Assert.Greater(nlb.Count, 0);

                int index = nlb.FindIndex(n => n.Symbol == "BTCUSDT");
                Assert.AreNotEqual(-1, index);

                Assert.Greater(nlb[0].Brackets.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
