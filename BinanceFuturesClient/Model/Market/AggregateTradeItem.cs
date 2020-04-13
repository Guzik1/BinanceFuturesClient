using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Aggregate trade item model for reponse on <see cref="BinanceFuturesClient.Market.GetOldTradesLookup(string, int)"/> and <see cref="BinanceFuturesClient.Market.GetOldTradesLookup(string, long, int)"/> request.
    /// </summary>
    public class AggregateTradeItem
    {
        /// <summary>
        /// Aggregate trade id
        /// </summary>
        [JsonProperty("a")]
        public long AggregateTradeId { get; set; }

        /// <summary>
        /// Trade price.
        /// </summary>
        [JsonProperty("p")]
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity in trade.
        /// </summary>
        [JsonProperty("q")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// First trade id.
        /// </summary>
        [JsonProperty("f")]
        public long FirstTradeId { get; set; }

        /// <summary>
        /// Last trade id.
        /// </summary>
        [JsonProperty("l")]
        public long LastTradeId { get; set; }

        /// <summary>
        /// Trade timestamp in unix milisecond.
        /// </summary>
        [JsonProperty("T")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Was the buyer the maker?
        /// </summary>
        [JsonProperty("m")]
        public bool BuyerIsTheMaker { get; set; }
    }
}
