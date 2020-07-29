using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{
    internal static class Config
    {
        // https://testnet.binancefuture.com/
        // http://localhost:1234/
        const string TestNetUrl = "https://testnet.binancefuture.com/";
        const string ApiUrl = "https://fapi.binance.com/";

        static string Url { get; set; } = ApiUrl;

        internal static bool IsTestnet { get; private set; } = false;

        internal static string ApiPublicUrl { 
            get { 
                return Url + "fapi/v1/"; 
            }
        }

        internal static string ApiPublicV2Url
        {
            get
            {
                return Url + "fapi/v2/";
            }
        }

        internal static string ApiFuturesDataUrl { 
            get 
            { 
                return Url + "futures/data/"; 
            }
        }

        internal static string ApiPrivateUrl { 
            get
            { 
                return Url + "sapi/v1/futures";
            }
        }

        internal static string ApiAccountTransferAndHistoryUrl
        {
            get
            {
                return @"https://api.binance.com/sapi/v1/futures/";
            }
        }

        internal static void UseTestnet(bool use)
        {
            if (use)
            {
                Url = TestNetUrl;
                IsTestnet = true;
            }
            else
            {
                IsTestnet = false;
                Url = ApiUrl;
            }

        }
    }
}
