using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Change isolated postion margin object response on <see cref="GBinanceFuturesClient.Trade.ChangeMarginType(string, MarginType, long)"/> request.
    /// </summary>
    public class ChangedIsolatedPostionMargin
    {
        /// <summary>
        /// Amount of margin
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Response code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Respone message
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Modif position margin type: 1: Add position margin，2: Reduce position margin.
        /// </summary>
        public int Type { get; set; }
    }
}
