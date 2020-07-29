using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Single ordre/trade/position item.
    /// </summary>
    public class AccountTradeItem
    {
        /// <summary>
        /// It's buyer
        /// </summary>
        public bool Buyer { get; set; }

        /// <summary>
        /// Commission
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// Commission asset, currency code.
        /// </summary>
        [JsonProperty("commissionAsset")]
        public string CommissionAsset { get; set; }

        /// <summary>
        /// Postion identificator
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// It's maker
        /// </summary>
        public bool Maker { get; set; }

        /// <summary>
        /// Order identificator
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Order quote quantity
        /// </summary>
        [JsonProperty("quoteQty")]
        public decimal QuoteQuantity { get; set; }

        /// <summary>
        /// Realized Pnl
        /// </summary>
        [JsonProperty("realizedPnl")]
        public decimal RealizedPnl { get; set; }

        /// <summary>
        /// Order side: BUY or SELL
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Postion side
        /// </summary>
        [JsonProperty("positionSide")]
        public PositionSide PositionSide { get; set; }

        /// <summary>
        /// Currency pair code
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Time in unix milisecond
        /// </summary>
        public long Time { get; set; }
    }
}
