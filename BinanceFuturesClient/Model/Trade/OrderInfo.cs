using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Data model for order information.
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// Client custom order identificator.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Cum quote.
        /// </summary>
        [JsonProperty("cumQuote")]
        public decimal CumQuote { get; set; }

        /// <summary>
        /// Executed quantity.
        /// </summary>
        [JsonProperty("executedQty")]
        public decimal ExecutedQty { get; set; }

        /// <summary>
        /// Order identificator.
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// Original quantity.
        /// </summary>
        [JsonProperty("origQty")]
        public decimal OrigQty { get; set; }

        /// <summary>
        /// Order price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Reduce only.
        /// </summary>
        [JsonProperty("reduceOnly")]
        public bool ReduceOnly { get; set; }

        /// <summary>
        /// Order side: buy or sell.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order position side: long, shor, both.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("positionSide")]
        public PositionSide PositionSide { get; set; }

        /// <summary>
        /// Order status.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Stop price.
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        /// <summary>
        /// Currency pair symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Time in force.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("timeInForce")]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Offer type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType Type { get; set; }

        /// <summary>
        /// Order activate price.
        /// </summary>
        [JsonProperty("activatePrice")]
        public decimal ActivatePrice { get; set; }

        /// <summary>
        /// Price rate.
        /// </summary>
        [JsonProperty("priceRate")]
        public decimal PriceRate { get; set; }

        /// <summary>
        /// Order update time.
        /// </summary>
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        /// <summary>
        /// Order working type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("workingType")]
        public WorkingType WorkingType { get; set; }
    }
}
