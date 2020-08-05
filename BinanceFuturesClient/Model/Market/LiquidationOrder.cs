using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetLiquidationOrders(string, int)"/> and
    /// <see cref="GBinanceFuturesClient.Market.GetLiquidationOrders(string, int)"/> request.
    /// </summary>
    public class LiquidationOrder
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Order price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order amount.
        /// </summary>
        [JsonProperty("origQty")]
        public decimal OrigQty { get; set; }

        /// <summary>
        /// Executed quantity.
        /// </summary>
        [JsonProperty("executedQty")]
        public decimal ExecutedQty { get; set; }

        /// <summary>
        /// Avrage price.
        /// </summary>
        [JsonProperty("avragePrice")]
        public decimal AvragePrice { get; set; }

        /// <summary>
        /// Order status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Time in force.
        /// </summary>
        [JsonProperty("timeInForce")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Order type, for example Limit.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType Type { get; set; }

        /// <summary>
        /// Side type: BUY or SELL.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Liquidation time in unix timestamp.
        /// </summary>
        public long Time { get; set; }
    }
}
