using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetNationalAndLeverageBrackets()"/> and
    /// <see cref="GBinanceFuturesClient.Market.GetNationalAndLeverageBrackets()"/> request.
    /// </summary>
    public class NationalAndLeverageBrackets
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// List of brackets for this currency symbol.
        /// </summary>
        public List<Brackets> Brackets { get; set; }
    }

    /// <summary>
    /// Brackets item.
    /// </summary>
    public class Brackets
    {
        /// <summary>
        /// National bracket.
        /// </summary>
        public int Bracket { get; set; }

        /// <summary>
        /// Max initial leverge for this bracket.
        /// </summary>
        [JsonProperty("initialLeverage")]
        public int InitialLeverage { get; set; }

        /// <summary>
        /// Cap notional of this bracket
        /// </summary>
        [JsonProperty("notionalCap")]
        public int NotionalCap { get; set; }

        /// <summary>
        /// Notionl threshold of this bracket 
        /// </summary>
        [JsonProperty("notionalFloor")]
        public int NotionalFloor { get; set; }

        /// <summary>
        /// Maintenance ratio for this bracket
        /// </summary>
        [JsonProperty("maintMarginRatio")]
        public decimal MaintMarginRatio { get; set; }
    }
}
