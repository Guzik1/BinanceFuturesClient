using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceFuturesClient
{
    internal class SessionData
    {
        internal string PublicKey { get; set; }

        internal string PrivateKey { get; set; }

        internal bool IsAutorized { get; set; }

        internal SessionData() {
            IsAutorized = false;
        }

        internal SessionData(string PublicApi, string PrivateApi)
        {
            PublicKey = PublicApi;
            PrivateKey = PrivateApi;
            IsAutorized = true;
        }
    }
}
