using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetOpenInterest(string)"/> request.
    /// </summary>
    public class OpenInterestItem
    {
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonProperty("openInterest")]
        public decimal OpenInterest { get; set; }

        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }
    }
}
