using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Trade;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class GetQueryOrderTests
    {
        GBinanceFuturesClient.Trade trade;

        [SetUp]
        public void OnSetup()
        {
            BinanceFuturesClient client = new BinanceFuturesClient(Config.PublicKey, Config.PrivateKey);
            client.UseTestnet(true);
            trade = client.Trade;
        }

        #region Get non-existent order
        [Test]
        public void GetNonExistentOrderUsingOrderId()
        {
            try
            {
                OrderInfo result = trade.GetOrder("BTCUSDT", 1546262163);
                Assert.IsNotNull(result);
            }
            catch (ErrorMessageException e)
            {
                if (e.Code != -2013)
                    Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetNonExistentOrderUsingClientOrderId()
        {
            try
            {
                OrderInfo result = trade.GetOrder("BTCUSDT", "testOrder");
                Assert.IsNotNull(result);
            }
            catch (ErrorMessageException e)
            {
                if(e.Code != -2013)
                    Tools.OnThrowErrorMessageException(e);
            }
        }
        #endregion

        #region Get existent order
        [Test]
        public void GetExistentOrderUsingOrderId()
        {
            try
            {
                NewOrderRequest order = new NewOrderRequest();
                order.SetMarketOrder("BTCUSDT", GBasicExchangeDefinitions.OrderSide.BUY, 0.5m);

                OrderInfo info = trade.PlaceOrder(order);

                OrderInfo result = trade.GetOrder("BTCUSDT", info.OrderId);

                Assert.IsNotNull(result);
                StringAssert.AreEqualIgnoringCase(info.ClientOrderId, result.ClientOrderId);
                Assert.AreEqual(info.OrderId, result.OrderId);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void GetExistentOrderUsingClientOrderId()
        {
            try
            {
                NewOrderRequest order = new NewOrderRequest();
                order.SetMarketOrder("BTCUSDT", GBasicExchangeDefinitions.OrderSide.BUY, 0.5m);

                OrderInfo info = trade.PlaceOrder(order);

                OrderInfo result = trade.GetOrder("BTCUSDT", info.ClientOrderId);

                Assert.IsNotNull(result);
                StringAssert.AreEqualIgnoringCase(info.ClientOrderId, result.ClientOrderId);
                Assert.AreEqual(info.OrderId, result.OrderId);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
        #endregion
    }
}
