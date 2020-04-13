using RestApiClient;
using System;

namespace BinanceFuturesClient
{
    internal static class Tools
    {
        internal static Expected TryGetResponse<Expected>(RestClient rc)
        {
            if (CheckResult(rc))
            {
                string response = rc.GetResponseToString;

                return JsonTools.DeserializeFromJson<Expected>(response);
            }

            throw new Exception("Unknown error.");
        }

        internal static dynamic TryGetResponseDynamic(RestClient rc)
        {
            if (CheckResult(rc))
            {
                string response = rc.GetResponseToString;

                return JsonTools.DeserializeFromJson(response);
            }

            throw new Exception("Unknown error.");
        }

        internal static bool CheckResult(RestClient rc)
        {
            if (rc.ResponseHasNoErrors())
            {
                //throw new Exception(rc.GetStatusCode + " - " + rc.GetResponseToString);

                return true;
            }
            else
                //return false;

            throw new Exception(rc.GetStatusCode + " - " + rc.GetResponseToString);
        }
    }
}
