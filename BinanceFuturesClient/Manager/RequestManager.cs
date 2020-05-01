using GBinanceFuturesClient.Inside;
using GBinanceFuturesClient.Model.Internal;
using RestApiClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Manager
{
    internal class RequestManager
    {
        SessionData session;
        Autorization autorization;
        RestClient client;

        internal RequestManager() { }

        internal RequestManager(SessionData session, Autorization autorization)
        {
            this.session = session;
            this.autorization = autorization;
        }

        internal Excepted SendRequest<Excepted>(MethodsType method, string url,
            Dictionary<string, string> query = null, object objectToSend = null)
        {
            SendRequestAndGetResponse(method, url, query, objectToSend);

            return TryGetResponse<Excepted>(client);
        }

        internal dynamic SendRequest(MethodsType method, string url,
            Dictionary<string, string> query = null, object objectToSend = null)
        {
            SendRequestAndGetResponse(method, url, query, objectToSend);

            return TryGetResponseDynamic(client);
        }

        void SendRequestAndGetResponse(MethodsType method, string url, Dictionary<string, string> query = null, object objectToSend = null)
        {
            client = new RestClient(url);
            string queryString = "";

            if (query != null)
                queryString = client.AddQuery(query);

            Autorize(queryString);

            client.Send(method, objectToSend);
        }

        void Autorize(string query = "")
        {
            // TODO throw exception when client is unautorized.

            if (autorization == Autorization.MARKET)
            {


                client.AddOwnHeaderToRequest(new AutenticateMarket(session));
            }
            else if (autorization == Autorization.TRADING)
            {

                client.AddOwnHeaderToRequest(new AutenticateTrade(session, query));
            }
        }

        Expected TryGetResponse<Expected>(RestClient rc)
        {
            if (CheckResult(rc))
            {
                string response = rc.GetResponseToString;

                return JsonTools.DeserializeFromJson<Expected>(response);
            }

            throw new Exception("Unknown error.");
        }

        dynamic TryGetResponseDynamic(RestClient rc)
        {
            if (CheckResult(rc))
            {
                string response = rc.GetResponseToString;

                return JsonTools.DeserializeFromJson(response);
            }

            throw new Exception("Unknown error.");
        }

        bool CheckResult(RestClient rc)
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
