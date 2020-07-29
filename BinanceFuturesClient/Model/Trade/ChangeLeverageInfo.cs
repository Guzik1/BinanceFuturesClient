using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Data model of leverage changed response on <see cref="GBinanceFuturesClient.Trade.ChangeLeverage(string, int, long)"/>
    /// </summary>
    public class ChangeLeverageInfo
    {
        /// <summary>
        /// Lavarage
        /// </summary>
        public int Laverage { get; set; }

        /// <summary>
        /// Max national value of leverage
        /// </summary>
        [JsonProperty("maxNotionalValue")]
        public long MaxNotionalValue { get; set; }

        /// <summary>
        /// Currency pair code for which lavarage changed
        /// </summary>
        public string Symbol { get; set; }
    }
}
