using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Trade;
using GBasicExchangeDefinitions;

namespace BinanceIntegratedTests.Trade
{
    public class NewOrderTests
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
        public void NewLimitOrderTest()
        {
            try
            {
                NewOrderRequest request = new NewOrderRequest();
                request.SetLimitOrder("BTCUSDT", OrderSide.BUY, 0.02m, 10000);

                OrderInfo response = trade.PlaceOrder(request);

                Assert.Greater(response.OrderId, 0);
                Assert.AreEqual(0.02m, response.OrigQty);
                Assert.AreEqual(10000, response.Price);
                Assert.AreEqual(OrderSide.BUY, response.Side);
                //Assert.AreEqual(PositionSide.LONG, response.PositionSide);
                StringAssert.AreEqualIgnoringCase("BTCUSDT", response.Symbol);
                Assert.AreEqual(OrderType.LIMIT, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void NewMarketOrderTest()
        {
            try
            {
                NewOrderRequest request = new NewOrderRequest();
                request.SetMarketOrder("BTCUSDT", OrderSide.SELL, 0.01m);
                request.NewClientOrderId = "test2";

                OrderInfo response = trade.PlaceOrder(request);

                StringAssert.AreEqualIgnoringCase("test2", response.ClientOrderId);
                Assert.Greater(response.OrderId, 0);
                Assert.AreEqual(0.01m, response.OrigQty);
                Assert.AreEqual(OrderSide.SELL, response.Side);
                Assert.AreEqual(PositionSide.BOTH, response.PositionSide);
                StringAssert.AreEqualIgnoringCase("BTCUSDT", response.Symbol);
                Assert.AreEqual(OrderType.MARKET, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void NewStopLimitOrderTest()
        {
            try
            {
                NewOrderRequest request = new NewOrderRequest();
                request.SetStopLimitOrder("BTCUSDT", OrderSide.SELL, 0.05m, 8000, 7990);

                OrderInfo response = trade.PlaceOrder(request);

                Assert.Greater(response.OrderId, 0);
                Assert.AreEqual(0.05m, response.OrigQty);
                Assert.AreEqual(7990, response.StopPrice);
                Assert.AreEqual(8000, response.Price);
                //Assert.AreEqual(OrderSide.SELL, response.Side);
                Assert.AreEqual(PositionSide.BOTH, response.PositionSide);
                StringAssert.AreEqualIgnoringCase("BTCUSDT", response.Symbol);
                Assert.AreEqual(OrderType.STOP, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void NewTakeProfitOrderTest()
        {
            try
            {
                NewOrderRequest request = new NewOrderRequest();
                request.SetTakeProfitLimitOrder("BTCUSDT", OrderSide.BUY, 0.1m, 8000m, 8010m);

                OrderInfo response = trade.PlaceOrder(request);

                Assert.Greater(response.OrderId, 0);
                Assert.AreEqual(0.1m, response.OrigQty);
                Assert.AreEqual(8010m, response.StopPrice);
                Assert.AreEqual(8000m, response.Price);
                Assert.AreEqual(OrderSide.BUY, response.Side);
                Assert.AreEqual(PositionSide.BOTH, response.PositionSide);
                StringAssert.AreEqualIgnoringCase("BTCUSDT", response.Symbol);
                Assert.AreEqual(OrderType.TAKE_PROFIT, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
