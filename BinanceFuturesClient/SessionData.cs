using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceFuturesClient
{
    internal class SessionData
    {
        internal SessionData(string PublicApi, string PrivateApi)
        {
            PublicApiKey = PublicApi;
            PrivateApiKey = PrivateApi;
        }

        internal string PublicApiKey { get; set; }

        internal string PrivateApiKey { get; set; }
    }
}
