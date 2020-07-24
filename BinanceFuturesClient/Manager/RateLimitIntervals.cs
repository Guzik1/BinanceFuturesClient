using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Manager
{
    /// <summary>
    /// Rate limit time intervals.
    /// </summary>
    public enum RateLimitIntervals
    {
        /// <summary> seconds. </summary>
        SECOND,
        /// <summary> minutes. </summary>
        MINUTE,
        /// <summary> days. </summary>
        DAY
    }
}
