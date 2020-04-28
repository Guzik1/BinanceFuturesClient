using GBinanceFuturesClient.Model.Internal;
using RestApiClient;
using System;
using System.Collections.Generic;

namespace GBinanceFuturesClient
{
    internal static class Tools
    {
        internal static Excepted GetFromServer<Excepted>(string url)
        {
            RestClient client = new RestClient(url);
            client.SendGET();

            return TryGetResponse<Excepted>(client);
        }

        internal static Excepted GetFromServer<Excepted>(string url, string symbol)
        {
            RestClient client = new RestClient(url);

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            client.AddQuery(query);
            client.SendGET();

            return TryGetResponse<Excepted>(client);
        }

        internal static Expected TryGetResponse<Expected>(RestClient rc)
        {
            if (CheckResult(rc))
            {
                string response = rc.GetResponseToString;

                return JsonTools.DeserializeFromJson<Expected>(response);
            }

            throw new Exception("Unknown error.");
        }

        internal static void CheckAutorizatioWhenUnautorizedThrowException(SessionData session)
        {
            if(session.IsAutorized == false)
                throw new Exception("Client is unautorized, use SetAutorizationData() method for autorize client."); 
            //TODO change this exception to UnautorizedClientException();
        }

        internal static long NowUnixTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
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

        static bool CheckResult(RestClient rc)
        {
            if (rc.ResponseHasNoErrors())
                return true;
            else
            {
                ErrorMessage error = JsonTools.DeserializeFromJson<ErrorMessage>(rc.GetResponseToString);
                throw new ErrorMessageException(error.Code, error.Msg);
            }
        }
    }
}
