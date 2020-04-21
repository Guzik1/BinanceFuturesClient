using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetOpenInterestStatistics(string, string, int)"/> and
    /// <see cref="GBinanceFuturesClient.Market.GetOpenInterestStatistics(string, string, long, long, int)"/> request.
    /// </summary>
    public class OpenInterestStatistics
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Total open inerest 
        /// </summary>
        [JsonProperty("sumOpenInterest")]
        public decimal SumOpenInterest { get; set; }

        /// <summary>
        /// Total open interet value
        /// </summary>
        [JsonProperty("sumOpenInterestValue")]
        public decimal SumOpenInterestValue { get; set; }

        /// <summary>
        /// Unix timestamp.
        /// </summary>
        public long Timestamp { get; set; }
    }
}
