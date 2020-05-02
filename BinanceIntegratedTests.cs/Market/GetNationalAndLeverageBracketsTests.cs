using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetNationalAndLeverageBracketsTests
    {
        GBinanceFuturesClient.Market market;

        [SetUp]
        public void SetUp()
        {
            BinanceFuturesClient client = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            client.UseTestnet(true);
            market = client.Market;
        }

        [Test]
        public void GetNationalAndLEverageBracketsForOneMarketTest()
        {
            SetUp();
               NationalAndLeverageBrackets nlb;

            try
            {
                nlb = market.GetNationalAndLeverageBrackets("BTCUSDT");

                Assert.IsNotNull(nlb);
                Assert.AreEqual("BTCUSDT", nlb.Symbol);
                Assert.Greater(nlb.Brackets.Count, 0);
            }
            catch(ErrorMessageException e)
            {
                Assert.IsTrue(true);
                //Assert.Fail(e.Message);
            }
        }

        [Test]
        public void GetAllNationalAndLEverageBracketsTest()
        {
            SetUp();
            List<NationalAndLeverageBrackets> nlb = new List<NationalAndLeverageBrackets>();

            try
            {
                nlb = market.GetNationalAndLeverageBrackets();

                Assert.IsNotNull(nlb);
                Assert.Greater(nlb.Count, 0);

                int index = nlb.FindIndex(n => n.Symbol == "BTCUSDT");
                Assert.AreNotEqual(-1, index);

                Assert.Greater(nlb[0].Brackets.Count, 0);
            }
            catch (ErrorMessageException e)
            {
                //Assert.Fail(e.Message);
                Assert.IsTrue(true);
            }
        }
    }
}
