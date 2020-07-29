using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Postion information item
    /// </summary>
    public class PositionInforamtionItem
    {
        /// <summary>
        /// Entry price
        /// </summary>
        [JsonProperty("entryPrice")]
        public decimal EntryPrice { get; set; }

        /// <summary>
        /// Margin type: ISOLATED or CROSS
        /// </summary>
        [JsonProperty("marginType")]
        public MarginType MarginType { get; set; }

        /// <summary>
        /// Is auto add margin
        /// </summary>
        [JsonProperty("isAutoAddMargin")]
        public bool IsAutoAddMargin { get; set; }

        /// <summary>
        /// Isolated margin
        /// </summary>
        [JsonProperty("isolatedMargin")]
        public decimal IsolatedMargin { get; set; }

        /// <summary>
        /// Leverage
        /// </summary>
        public int Leverage { get; set; }

        /// <summary>
        /// Liquidation price
        /// </summary>
        [JsonProperty("liquidationPrice")]
        public decimal LiquidationPrice { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("markPrice")]
        public decimal MarkPrice { get; set; }

        /// <summary>
        /// Max notional value
        /// </summary>
        [JsonProperty("maxNotionalValue")]
        public decimal MaxNotionalValue { get; set; }

        /// <summary>
        /// Position amount
        /// </summary>
        [JsonProperty("positionAmt")]
        public decimal PositionAmount { get; set; }

        /// <summary>
        /// Currency pari code
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Un-realized profit
        /// </summary>
        [JsonProperty("unRealizedProfit")]
        public decimal UnRealizedProfit { get; set; }

        /// <summary>
        /// Position side
        /// </summary>
        public PositionSide PositionSide { get; set; }
    }
}
