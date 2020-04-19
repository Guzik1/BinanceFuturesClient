using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="BinanceFuturesClient.Market.GetOpenInterest(string)"/> request.
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
