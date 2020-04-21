using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    //TODO: ADD docs
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
