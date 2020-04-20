using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for <see cref="GBinanceFuturesClient.Market.GetOrderBookTicker()"/> and 
    /// <see cref="GBinanceFuturesClient.Market.GetOrderBookTicker(string)"/> request.
    /// </summary>
    public class OrderBookTicker
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Bid price.
        /// </summary>
        [JsonProperty("bidPrice")]
        public decimal BidPrice { get; set; }

        /// <summary>
        /// Bid quantity
        /// </summary>
        [JsonProperty("bidQty")]
        public decimal BidQty { get; set; }

        /// <summary>
        /// Ask price.
        /// </summary>
        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }

        /// <summary>
        /// Ask quantity.
        /// </summary>
        [JsonProperty("askQty")]
        public decimal AskQty { get; set; }
    }
}
