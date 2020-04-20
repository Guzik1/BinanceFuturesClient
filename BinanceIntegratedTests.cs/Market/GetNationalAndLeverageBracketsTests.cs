using GBinanceFuturesClient.Model.Market;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Market
{
    public class GetNationalAndLeverageBracketsTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient(Config.PublicKey, Config.PrivateKey).Market;

        [Test]
        public void GetNationalAndLEverageBracketsForOneMarketTest()
        {
            NationalAndLeverageBrackets nlb = market.GetNationalAndLeverageBrackets("BTCUSDT");

            Assert.IsNotNull(nlb);
            Assert.AreEqual("BTCUSDT", nlb.Symbol);
            Assert.Greater(nlb.Brackets.Count, 0);
        }

        [Test]
        public void GetAllNationalAndLEverageBracketsTest()
        {
            List<NationalAndLeverageBrackets> nlb = market.GetNationalAndLeverageBrackets();

            Assert.IsNotNull(nlb);
            Assert.Greater(nlb.Count, 0);

            int index = nlb.FindIndex(n => n.Symbol == "BTCUSDT");
            Assert.AreNotEqual(-1, index);

            Assert.Greater(nlb[0].Brackets.Count, 0);
        }
    }
}
