using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    //TODO: ADD docs (add new method in see block)
    /// <summary>
    /// Data model used in repspone on <see cref="GBinanceFuturesClient.Market.GetTopTradeLongShortAccountsRatio(string, string, int)"/>, 
    /// <see cref="GBinanceFuturesClient.Market.GetTopTradeLongShortPositionsRatio(string, string, int)"/> and 
    /// <see cref=""/>
    /// </summary>
    public class RatioItem
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Long/short account num ratio of top traders.
        /// </summary>
        [JsonProperty("longShortRatio")]
        public decimal LongShortRatio { get; set; }

        /// <summary>
        /// Long account num ratio of top traders.
        /// </summary>
        [JsonProperty("longAccount")]
        public decimal LongAccount { get; set; }

        /// <summary>
        /// Long account num ratio of top traders.
        /// </summary>
        [JsonProperty("shortAccount")]
        public decimal ShortAccount { get; set; }

        /// <summary>
        /// Unix milisecond timestamp.
        /// </summary>
        public long Timestamp { get; set; }
    }
}
