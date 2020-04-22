using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for repspone on <see cref="GBinanceFuturesClient.Market.GetTakerBuySellVolume(string, string, int)"/> and
    /// <see cref="GBinanceFuturesClient.Market.GetTakerBuySellVolume(string, string, long, long, int)"/> request.
    /// </summary>
    public class BuySellVolume
    {
        /// <summary>
        /// Buy sell volume ratio.
        /// </summary>
        [JsonProperty("buySellRatio")]
        public decimal BuySellRatio { get; set; }

        /// <summary>
        /// Buy volume.
        /// </summary>
        [JsonProperty("buyVol")]
        public decimal BuyVol { get; set; }

        /// <summary>
        /// Sell volume.
        /// </summary>
        [JsonProperty("sellVol")]
        public decimal SellVol { get; set; }

        /// <summary>
        /// Unix milisecond timestamp.
        /// </summary>
        public long Timestamp { get; set; }
    }
}
