using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Manager
{
    /// <summary>
    /// Rate limit type enum.
    /// </summary>
    public enum RateLimiters
    {
        /// <summary> Request weight limit. </summary>
        REQUEST_WEIGHT,
        /// <summary> Orders limit. </summary>
        ORDERS
    }
}
