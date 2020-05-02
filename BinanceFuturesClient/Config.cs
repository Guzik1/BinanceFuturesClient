using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{
    internal static class Config
    {
        const string TestNetUrl = "https://testnet.binancefuture.com";

        const string ApiUrl = "https://fapi.binance.com/";

        static string Url { get; set; } = ApiUrl;

        internal static bool IsTestnet { get; private set; } = false;

        internal static string ApiPublicUrl { 
            get { 
                return ApiUrl + "fapi/v1/"; 
            }
        }

        internal static string ApiFuturesDataUrl { 
            get 
            { 
                return ApiUrl + "futures/data/"; 
            }
        }

        internal static string ApiPrivateUrl { 
            get
            { 
                return ApiUrl + "sapi/v1/futures";
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
