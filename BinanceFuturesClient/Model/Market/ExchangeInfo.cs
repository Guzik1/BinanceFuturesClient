using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Response model for <see cref="BinanceFuturesClient.Market.GetExchangeInfo()"/> request.
    /// </summary>
    public class ExchangeInfo
    {
        /// <summary>
        /// Exchange filters.
        /// </summary>
        [JsonProperty("exchangeFilters")]
        public List<string> ExchangeFilters { get; set; }

        /// <summary>
        /// List of rate limits.
        /// </summary>
        [JsonProperty("rateLimits")]
        public List<RateLimitItem> RateLimits { get; set; }

        /// <summary>
        /// Server time in unix milisecond timestamp.
        /// </summary>
        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }

        /// <summary>
        /// List of details for one market.
        /// </summary>
        public List<SymbolItem> Symbols { get; set; }

        /// <summary>
        /// Time zone.
        /// </summary>
        public string Timezone { get; set; }
    }

    /// <summary>
    /// Rate limit details.
    /// </summary>
    public class RateLimitItem
    {
        /// <summary>
        /// Time interval step
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// Internal number.
        /// </summary>
        [JsonProperty("intervalNum")]
        public int IntervalNum { get; set; }

        /// <summary>
        /// Limit count.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Limit type.
        /// </summary>
        [JsonProperty("rateLimitType")]
        public string RateLimitType { get; set; }
    }

    /// <summary>
    /// Details for market.
    /// </summary>
    public class SymbolItem
    {
        /// <summary>
        /// Market code.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Status of market, default trading.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Maint Margin Procent.
        /// </summary>
        [JsonProperty("maintMarginPercent")]
        public decimal MaintMarginPercent { get; set; }

        /// <summary>
        /// Maint Margin Procent.
        /// </summary>
        [JsonProperty("requiredMarginPercent")]
        public decimal RequiredMarginPercent { get; set; }

        /// <summary>
        /// Base/first currency in symbol.
        /// </summary>
        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }

        /// <summary>
        /// Quote/second currency in symbol.
        /// </summary>
        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }

        /// <summary>
        /// Number of decimal places in price.
        /// </summary>
        [JsonProperty("pricePrecision")]
        public int PricePrecision { get; set; }

        /// <summary>
        /// Number of decimal places in quantity.
        /// </summary>
        [JsonProperty("quantityPrecision")]
        public int QuantityPrecision { get; set; }

        /// <summary>
        /// Number of decimal places in base currencies.
        /// </summary>
        [JsonProperty("baseAssetPrecision")]
        public int BaseAssetPrecision { get; set; }

        /// <summary>
        /// Number of decimal places in second currencies.
        /// </summary>
        [JsonProperty("quotePrecision ")]
        public int QuotePrecision { get; set; }

        /// <summary>
        /// List of market filters.
        /// </summary>
        //TODO: change this to implemented object.
        public List<object> Filters { get; set; }

        /// <summary>
        /// List of order types.
        /// </summary>
        public List<string> OrderTypes { get; set; }

        /// <summary>
        /// Time in foce types.
        /// </summary>
        public List<string> TimeInForce { get; set; }
    }
}
