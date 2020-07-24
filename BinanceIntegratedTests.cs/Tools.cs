using GBinanceFuturesClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceIntegratedTests
{
    internal static class Tools
    {
        internal static void OnThrowErrorMessageException(ErrorMessageException e)
        {
            Assert.Fail(e.Code + ": " + e.Message);
        }

        internal static long NowUnixTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        internal static long NowUnixTimeMinusDays(int days)
        {
            return DateTimeOffset.UtcNow.AddDays(days).ToUnixTimeMilliseconds();
        }
    }
}
