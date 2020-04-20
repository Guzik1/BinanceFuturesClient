using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Response model for <see cref="GBinanceFuturesClient.Market.GetOrderBook(string)"/> and <see cref="GBinanceFuturesClient.Market.GetOrderBook(string)"/> request.
    /// </summary>
    public class OrderBook
    {
        /// <summary>
        /// Last update identificator.
        /// </summary>
        [JsonProperty("lastUpdateId")]
        public long LastUpdateId { get; set; }

        /// <summary>
        /// Bid offers list, first element on insiding list is price, second is quantity.
        /// </summary>
        public List<List<decimal>> Bids { get; set; }

        /// <summary>
        /// Ask offers list, first element on insiding list is price, second is quantity.
        /// </summary>
        public List<List<decimal>> Asks { get; set; }
    }
}
