using GBinanceFuturesClient;
using NUnit.Framework;

namespace BinanceIntegratedTests.Market
{
    public class DebugMethodsTests
    {
        GBinanceFuturesClient.Market market = new GBinanceFuturesClient.BinanceFuturesClient().Market;

        [Test]
        public void PingTest()
        {
            try
            {
                Assert.IsTrue(market.Ping());
            }
            catch(ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void ServerTimeTest()
        {
            try
            {
                long time = market.GetServerTime();

                Assert.Greater(time, 0);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }


    }
}