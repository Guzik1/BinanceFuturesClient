using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Trade;
using GBasicExchangeDefinitions;

namespace BinanceIntegratedTests.Trade
{
    public class OrderTests
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
        public void LimitOrderTest()
        {
            try
            {
                // Place order
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

                // Cancel order
                response = trade.CancelOrder("BTCUSDT", response.OrderId);

                Assert.AreEqual(OrderStatus.CANCELED, response.Status);
                Assert.AreEqual(0.02m, response.OrigQty);
                Assert.AreEqual(10000, response.Price);
                Assert.AreEqual(OrderType.LIMIT, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void MarketOrderTest()
        {
            try
            {
                NewOrderRequest request = new NewOrderRequest();
                request.SetMarketOrder("BTCUSDT", OrderSide.SELL, 0.06m);

                OrderInfo response = trade.PlaceOrder(request);

                Assert.Greater(response.OrderId, 0);
                Assert.AreEqual(0.06m, response.OrigQty);
                Assert.AreEqual(OrderSide.SELL, response.Side);
                Assert.AreEqual(PositionSide.BOTH, response.PositionSide);
                StringAssert.AreEqualIgnoringCase("BTCUSDT", response.Symbol);
                Assert.AreEqual(OrderType.MARKET, response.Type);

                response = trade.GetOrder("BTCUSDT", response.OrderId);
                Assert.AreEqual(OrderStatus.FILLED, response.Status);

                if (response.Status != OrderStatus.FILLED)
                {
                    // Cancel order
                    response = trade.CancelOrder("BTCUSDT", response.OrderId);

                    Assert.AreEqual(OrderStatus.CANCELED, response.Status);
                    Assert.Greater(response.OrderId, 0);
                    Assert.AreEqual(0.06m, response.OrigQty);
                    Assert.AreEqual(OrderSide.SELL, response.Side);
                    Assert.AreEqual(OrderType.MARKET, response.Type);
                }
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void StopLimitOrderTest()
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

                // Cancel order
                response = trade.CancelOrder("BTCUSDT", response.ClientOrderId);

                Assert.AreEqual(OrderStatus.CANCELED, response.Status);
                Assert.AreEqual(0.05m, response.OrigQty);
                Assert.AreEqual(7990, response.StopPrice);
                Assert.AreEqual(8000, response.Price);
                Assert.AreEqual(OrderType.STOP, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }

        [Test]
        public void TakeProfitOrderTest()
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

                // Cancel order
                response = trade.CancelOrder("BTCUSDT", response.ClientOrderId);

                Assert.AreEqual(OrderStatus.CANCELED, response.Status);
                Assert.AreEqual(0.1m, response.OrigQty);
                Assert.AreEqual(8010m, response.StopPrice);
                Assert.AreEqual(8000m, response.Price);
                Assert.AreEqual(OrderType.TAKE_PROFIT, response.Type);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
