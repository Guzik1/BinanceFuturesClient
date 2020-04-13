using NUnit.Framework;
using BinanceFuturesClient;

namespace BinanceIntegratedTests.Market
{
    public class DebugMethodsTests
    {
        BinanceFuturesClient.Market market = new BinanceFuturesClient.Market();

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