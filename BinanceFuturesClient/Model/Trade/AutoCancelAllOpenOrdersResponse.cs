using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Auto-cancel all open orders response on <see cref="GBinanceFuturesClient.Trade.AutoCancelAllOpenOrders(string, long)"/> and 
    /// <see cref="GBinanceFuturesClient.Trade.AutoCancelAllOpenOrders(string, long, long)"/> request.
    /// </summary>
    public class AutoCancelAllOpenOrdersResponse
    {
        /// <summary>
        /// Currency pair code.
        /// </summary>
        public string Symbol;

        /// <summary>
        /// Countdown timer in miliseconds.
        /// </summary>
        [JsonProperty("countdownTime")]
        public long CountdownTimer;
    }
}
