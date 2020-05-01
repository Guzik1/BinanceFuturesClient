using GBinanceFuturesClient.Manager;
using GBinanceFuturesClient.Model.Internal;
using RestApiClient;
using System;
using System.Collections.Generic;

namespace GBinanceFuturesClient
{
    internal static class Tools
    {
        internal static long NowUnixTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
