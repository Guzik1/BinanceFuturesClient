using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Income history item
    /// </summary>
    public class IncomeHistoryItem
    {
        /// <summary>
        /// Currency pair code
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Income type
        /// </summary>
        [JsonProperty("incomeType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IncomeType IncomeType { get; set; }

        /// <summary>
        /// Income
        /// </summary>
        public decimal Income { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Information
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Time in unix milisecond timestamp
        /// </summary>
        public long Time { get; set; }
    }
}
