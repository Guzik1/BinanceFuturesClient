using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetMarkPrice()"/> and <see cref="GBinanceFuturesClient.Market.GetMarkPrice(string)"/> request.
    /// </summary>
    public class MarkPriceResponse
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Mark price.
        /// </summary>
        [JsonProperty("markPrice")]
        public decimal MarkPrice { get; set; }

        /// <summary>
        /// Last funding rate in percent.
        /// </summary>
        [JsonProperty("lastFundingRate")]
        public decimal LastFundingRate { get; set; }

        /// <summary>
        /// Next funding time in unix timestamp.
        /// </summary>
        public long NextFundingTime { get; set; }

        /// <summary>
        /// Server time.
        /// </summary>
        public long Time { get; set; }
    }
}
