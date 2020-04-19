using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Ticker data model for <see cref="BinanceFuturesClient.Market.Get24hTicker()"/> and <see cref="BinanceFuturesClient.Market.Get24hTicker(string)"/> request.
    /// </summary>
    public class Ticker24h
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 24 hours price change in base currency.
        /// </summary>
        [JsonProperty("priceChange")]
        public decimal PriceChange { get; set; }

        /// <summary>
        /// 24 hours price change in percent.
        /// </summary>
        [JsonProperty("priceChangePercent")]
        public decimal PriceChangePercent { get; set; }

        /// <summary>
        /// Weighted average price.
        /// </summary>
        [JsonProperty("weightedAvgPrice")]
        public decimal WeightedAvgPrice { get; set; }

        /// <summary>
        /// Prev close price.
        /// </summary>
        [JsonProperty("prevClosePrice")]
        public decimal PrevClosePrice { get; set; }

        /// <summary>
        /// Last transaction price.
        /// </summary>
        [JsonProperty("lastPrice")]
        public decimal LastPrice { get; set; }

        /// <summary>
        /// Last transaction quantity.
        /// </summary>
        [JsonProperty("lastQty")]
        public decimal LastQty { get; set; }

        /// <summary>
        /// Open price.
        /// </summary>
        [JsonProperty("openPrice")]
        public decimal OpenPrice { get; set; }

        /// <summary>
        /// High price.
        /// </summary>
        [JsonProperty("highPrice")]
        public decimal HighPrice { get; set; }

        /// <summary>
        /// Low price.
        /// </summary>
        [JsonProperty("lowPrice")]
        public decimal LowPrice { get; set; }

        /// <summary>
        /// 24 hours volume in base currency.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// 24 hours volume in quote currency.
        /// </summary>
        [JsonProperty("quoteVolume")]
        public decimal QuoteVolume { get; set; }

        /// <summary>
        /// Open time, unix timestamp.
        /// </summary>
        [JsonProperty("openTime")]
        public long OpenTime { get; set; }

        /// <summary>
        /// Close time, unix timestamp.
        /// </summary>
        [JsonProperty("closeTime")]
        public long CloseTime { get; set; }

        /// <summary>
        /// First trade identificator.
        /// </summary>
        [JsonProperty("firstId")]
        public long FirstId { get; set; }

        /// <summary>
        /// Last trade identificator.
        /// </summary>
        [JsonProperty("lastId")]
        public long LastId { get; set; }

        /// <summary>
        /// Trade count in 24 hours.
        /// </summary>
        public long Count { get; set; }
    }
}
