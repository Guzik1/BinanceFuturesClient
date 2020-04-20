using NUnit.Framework;

namespace BinanceIntegratedTests.Market
{
    public class DebugMethodsTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void PingTest()
        {
            Assert.IsTrue(market.Ping());
        }

        [Test]
        public void ServerTimeTest()
        {
            long time = market.GetServerTime();

            Assert.Greater(time, 0);
        }


    }
}