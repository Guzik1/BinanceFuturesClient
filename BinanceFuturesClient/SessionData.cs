using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{
    internal class SessionData
    {
        internal string PublicKey { get; set; }

        internal string PrivateKey { get; set; }

        internal bool IsMarketAutorized { get; set; }

        internal bool IsTradingAutorized { get; set; }

        internal SessionData() {
            IsMarketAutorized = false;
            IsTradingAutorized = false;
        }

        internal SessionData(string publicApi)
        {
            Autorize(publicApi);
        }

        internal SessionData(string publicApi, string privateApi)
        {
            Autorize(publicApi, privateApi);
        }

        internal void Autorize(string publicApi, string privateApi = "")
        {
            PublicKey = publicApi;
            PrivateKey = privateApi;

            IsMarketAutorized = false;

            if(privateApi.Length != 0)
                IsTradingAutorized = true;
            else 
                IsTradingAutorized = false;
        }
    }
}
