using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceFuturesClient.Model.Market
{    
    /// <summary>
     /// Data model for response on <see cref="BinanceFuturesClient.Market.GetFundingRateHistory(string, int)"/> 
     /// and <see cref="BinanceFuturesClient.Market.GetFundingRateHistory(string, long, long, int)"/> request.
     /// </summary>
    public class FundingRateHistory
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Funding rate in percent.
        /// </summary>
        [JsonProperty("fundingRate")]
        public decimal FundingRate { get; set; }

        /// <summary>
        /// Funding time in unix timestamp.
        /// </summary>
        [JsonProperty("fundingTime")]
        public long FundingTime { get; set; }
    }
}
