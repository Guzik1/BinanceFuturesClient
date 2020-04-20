using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Market.GetSymbolPriceTicker()"/> and 
    /// <see cref="GBinanceFuturesClient.Market.GetSymbolPriceTicker(string)"/> request.
    /// </summary>
    public class PriceTicker
    {
        /// <summary>
        /// Currency pair symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Price for currency pair.
        /// </summary>
        public decimal Price { get; set; }
    }
}
