using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{

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
