using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Data model for item of postion margin change history.
    /// </summary>
    public class PostionMarginChangeHistoryItem
    {
        /// <summary>
        /// Change amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Asset, currency code
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Change time in unix milisecond
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Change type, 1: Add position margin，2: Reduce position margin
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Postion side
        /// </summary>
        [JsonProperty("positionSide")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PositionSide PositionSide { get; set; }
    }
}
