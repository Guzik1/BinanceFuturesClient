using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{
    internal class SessionData
    {
        internal string PublicKey { get; set; }

        internal string PrivateKey { get; set; }

        internal bool IsAutorized { get; set; }

        internal SessionData() {
            IsAutorized = false;
        }

        internal SessionData(string publicApi, string privateApi)
        {
            Autorize(publicApi, privateApi);
        }

        internal void Autorize(string publicApi, string privateApi)
        {
            PublicKey = publicApi;
            PrivateKey = privateApi;
            IsAutorized = true;
        }
    }
}
