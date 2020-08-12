using GBasicExchangeDefinitions;
using GBinanceFuturesClient.Inside;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Data model for use request in <see cref="GBinanceFuturesClient.Trade.PlaceOrder(NewOrderRequest)"/> request.
    /// </summary>
    public class NewOrderRequest
    {
        /// <summary>
        /// Currency pair symbol. Required.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Order side, buy or sell. Required.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        /// Default BOTH for One-way Mode, LONG or SHORT for Hedge Mode. It must be sent with Hedge Mode.
        /// </summary>
        [Inside.DefaultValue(PositionSide.BOTH)]
        public PositionSide PositionSide { get; set; } = PositionSide.BOTH;

        /// <summary>
        /// Order type. Required.
        /// </summary>
        public OrderType Type { get; set; } = OrderType.LIMIT;

        /// <summary>
        /// Time in force, default GTC. Required only in Limit order.
        /// </summary>
        [Inside.DefaultValue(TimeInForce.DEFAULT)]
        public TimeInForce TimeInForce { get; set; } = TimeInForce.DEFAULT;

        /// <summary>
        /// Order quantity. Required.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Reduce only, "true" or "false". Defalt "false".
        /// </summary>
        [Inside.DefaultValue(false)]
        public bool ReduceOnly { get; set; } = false;

        /// <summary>
        /// Order price.
        /// </summary>
        [Inside.DefaultValue]
        public decimal Price { get; set; }

        /// <summary>
        /// A unique id among open orders. Automatically generated if not sent. For each order NewClientOrderId, it must be different.
        /// </summary>
        [Inside.DefaultValue]
        public string NewClientOrderId { get; set; }

        /// <summary>
        /// Stop price. Used with STOP/STOP_MARKET or TAKE_PROFIT/TAKE_PROFIT_MARKET orders.
        /// </summary>
        [Inside.DefaultValue]
        public decimal StopPrice { get; set; }

        /// <summary>
        /// Order activation price. Used with TRAILING_STOP_MARKET orders, default as the latest price（supporting different workingType).
        /// </summary>
        [Inside.DefaultValue]
        public decimal ActivationPrice { get; set; }

        /// <summary>
        /// callback order price. Used with TRAILING_STOP_MARKET orders, min 0.1, max 5 where 1 for 1%.
        /// </summary>
        [Inside.DefaultValue]
        public decimal CallbackRate { get; set; }

        /// <summary>
        /// Working type. stopPrice triggered by: "MARK_PRICE", "CONTRACT_PRICE". Default "CONTRACT_PRICE"
        /// </summary>
        [Inside.DefaultValue(WorkingType.CONTRACT_PRICE)]
        public WorkingType WorkingType { get; set; } = WorkingType.CONTRACT_PRICE;

        /// <summary>
        /// New order response type, "ACK" or "RESULT", default "ACK".
        /// </summary>
        [Inside.DefaultValue(ResponseType.ACK)]
        public ResponseType NewOrderRespType { get; set; } = ResponseType.ACK;

        /*
        /// <summary>
        /// Unix milisecond timestamp.
        /// </summary>
        public long Timestamp { get; internal set; }*/

        /// <summary>
        /// Create limit order request.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <param name="timeInForce">Time in force, default: GTC</param>
        public NewOrderRequest SetLimitOrder(string symbol, OrderSide side, decimal quantity, decimal price, TimeInForce timeInForce = TimeInForce.GTC)
        {
            SetMarketOrder(symbol, side, quantity);
            Price = price;
            TimeInForce = timeInForce;
            Type = OrderType.LIMIT;

            return this;
        }

        /// <summary>
        /// Create market order request.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        public NewOrderRequest SetMarketOrder(string symbol, OrderSide side, decimal quantity)
        {
            Symbol = symbol;
            Side = side;
            Type = OrderType.MARKET;
            Quantity = quantity;

            return this;
        }

        /// <summary>
        /// Create stop limit order.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <param name="stopPrice">Stop price</param>
        public NewOrderRequest SetStopLimitOrder(string symbol, OrderSide side, decimal quantity, decimal price, decimal stopPrice)
        {
            SetStopMarketOrder(symbol, side, quantity, price, stopPrice);
            Price = price;
            Type = OrderType.STOP;

            return this;
        }

        /// <summary>
        /// Create take profit limit order.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <param name="stopPrice">Stop price</param>
        public NewOrderRequest SetTakeProfitLimitOrder(string symbol, OrderSide side, decimal quantity, decimal price, decimal stopPrice)
        {
            SetStopMarketOrder(symbol, side, quantity, price, stopPrice);
            Type = OrderType.TAKE_PROFIT;

            return this;
        }

        /// <summary>
        /// Create stop market order.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <param name="stopPrice">Stop price</param>
        public NewOrderRequest SetStopMarketOrder(string symbol, OrderSide side, decimal quantity, decimal price, decimal stopPrice)
        {
            SetMarketOrder(symbol, side, quantity);
            StopPrice = stopPrice;
            Price = price;
            Type = OrderType.STOP_MARKET;

            return this;
        }

        /// <summary>
        /// Create take profit market order.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price</param>
        /// <param name="stopPrice">Stop price</param>
        public NewOrderRequest SetTakeProfitMarketOrder(string symbol, OrderSide side, decimal quantity, decimal price, decimal stopPrice)
        {
            SetStopMarketOrder(symbol, side, quantity, price, stopPrice);
            Type = OrderType.TAKE_PROFIT_MARKET;

            return this;
        }

        /// <summary>
        /// Create trailing stop market order.
        /// </summary>
        /// <param name="symbol">Symbol string</param>
        /// <param name="side">Order side</param>
        /// <param name="callbackRate">Callback rate</param>
        public NewOrderRequest SetTrailingStopMarketOrder(string symbol, OrderSide side, decimal callbackRate)
        {
            Symbol = symbol;
            Side = side;
            Type = OrderType.TRAILING_STOP_MARKET;
            CallbackRate = callbackRate;

            return this;
        }
    }
}
