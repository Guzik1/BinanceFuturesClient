using GBasicExchangeDefinitions;
using GBinanceFuturesClient;
using GBinanceFuturesClient.Model.Trade;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests.Trade
{
    public class MultipleOrdersTests
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
        public void TwoLimitOrderTest()
        {
            List<NewOrderRequest> orders = new List<NewOrderRequest>();
            List<ValidOrErrorResponse<OrderInfo>> responseNew;
            bool[] filled = new bool[2];

            orders.Add(new NewOrderRequest().SetLimitOrder("BTCUSDT", OrderSide.BUY, 0.02m, 8000));
            orders.Add(new NewOrderRequest().SetLimitOrder("BTCUSDT", OrderSide.SELL, 0.01m, 12000));

            //Add new orders.
            try
            {
                responseNew = trade.PlaceMultipleOrders(orders);
            }catch(ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
                return;
            }

            for(int i = 0; i < responseNew.Count; i++)
            {
                if (responseNew[i].IsValid)
                {
                    Assert.AreNotEqual(OrderStatus.CANCELED, responseNew[i].ValidResponse.Status);

                    if (responseNew[i].ValidResponse.Status == OrderStatus.FILLED)
                        filled[i] = true;
                }
                else
                    Assert.Fail("Order fail response code " + responseNew[i].ErrorResponse.Code + ": " + responseNew[i].ErrorResponse.Msg);
            }

            /*for(int i = 0; i < responseNew.Count; i++)
            {
                Assert.AreEqual(true, filled[i], i.ToString());
            }*/
            /*if (responseNew[0].IsValid)
                trade.CancelOrder("BTCUSDT", responseNew[0].ValidResponse.OrderId);*/
            //Get orders and check status.
            List<OrderInfo> responseGet = new List<OrderInfo>();
            for (int i = 0; i < responseNew.Count; i++)
            {
                try
                {

                    if (responseNew[i].IsValid)
                        if(responseNew[i].ValidResponse.Status != OrderStatus.FILLED && responseNew[i].ValidResponse.Status != OrderStatus.EXPIRED &&
                            responseNew[i].ValidResponse.Status != OrderStatus.CANCELED)
                            responseGet.Add(trade.GetOrder("BTCUSDT", responseNew[i].ValidResponse.OrderId));
                    else
                        Assert.Fail("Order fail response code " + responseNew[i].ErrorResponse.Code + ": " + responseNew[i].ErrorResponse.Msg);
                }
                catch (ErrorMessageException){ }
            }

            //Delete orders.
            for(int i = 0; i < responseGet.Count; i++)
            {
                try
                {
                    trade.CancelOrder("BTCUSDT", responseGet[i].OrderId);
                }catch(ErrorMessageException e)
                {
                    Tools.OnThrowErrorMessageException(e);
                }
            }
        }

        [Test]
        public void AllOrderTypeTest()
        {
            List<NewOrderRequest> orders = new List<NewOrderRequest>();
            List<ValidOrErrorResponse<OrderInfo>> responseNew;
            bool[] filled = new bool[4];

            orders.Add(new NewOrderRequest().SetLimitOrder("BTCUSDT", OrderSide.BUY, 0.02m, 8000));
            orders.Add(new NewOrderRequest().SetMarketOrder("BTCUSDT", OrderSide.SELL, 0.01m));
            orders.Add(new NewOrderRequest().SetStopLimitOrder("BTCUSDT", OrderSide.SELL, 0.03m, 12000, 12010));
            orders.Add(new NewOrderRequest().SetStopMarketOrder("BTCUSDT", OrderSide.BUY, 0.02m, 6000, 6010));

            //Add new orders.
            try
            {
                responseNew = trade.PlaceMultipleOrders(orders);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
                return;
            }

            for (int i = 0; i < responseNew.Count; i++)
            {
                if (responseNew[i].IsValid)
                {
                    Assert.AreNotEqual(OrderStatus.CANCELED, responseNew[i].ValidResponse.Status);

                    if (responseNew[i].ValidResponse.Status == OrderStatus.FILLED)
                        filled[i] = true;
                }
                else
                    Assert.Fail("Order fail response code " + responseNew[i].ErrorResponse.Code + ": " + responseNew[i].ErrorResponse.Msg);
            }

            //Get orders and check status.
            List<OrderInfo> responseGet = new List<OrderInfo>();
            for (int i = 0; i < responseNew.Count; i++)
            {
                try
                {

                    if (responseNew[i].IsValid && !filled[i])
                        if (responseNew[i].ValidResponse.Status != OrderStatus.FILLED && responseNew[i].ValidResponse.Status != OrderStatus.EXPIRED &&
                            responseNew[i].ValidResponse.Status != OrderStatus.CANCELED)
                            responseGet.Add(trade.GetOrder("BTCUSDT", responseNew[i].ValidResponse.OrderId));
                        else
                            Assert.Fail("Order fail response code " + responseNew[i].ErrorResponse.Code + ": " + responseNew[i].ErrorResponse.Msg);
                }
                catch (ErrorMessageException) { }
            }

            List<long> orderId = new List<long>();
            //Delete orders.
            for (int i = 0; i < responseGet.Count; i++)
            {
                orderId.Add(responseGet[i].OrderId);
            }

            try
            {
                List<ValidOrErrorResponse<OrderInfo>> response = trade.CancelMultipleOrders("BTCUSDT", orderId);
            }
            catch (ErrorMessageException e)
            {
                Tools.OnThrowErrorMessageException(e);
            }
        }
    }
}
