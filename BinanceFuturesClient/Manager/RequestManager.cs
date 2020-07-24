using GBinanceFuturesClient.Inside;
using GBinanceFuturesClient.Internal;
using GBinanceFuturesClient.Model.Internal;
using GBinanceFuturesClient.Model.Trade;
using RestApiClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GBinanceFuturesClient.Manager
{
    internal class RequestManager
    {
        SessionData session;
        Autorization autorization;
        RestClient client;
        Dictionary<string, string> query = new Dictionary<string, string>();

        internal RequestManager() { }

        internal RequestManager(SessionData session, Autorization autorization)
        {
            this.session = session;
            this.autorization = autorization;
        }

        internal static Excepted GetFromServer<Excepted>(string url, SessionData session)
        {
            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<Excepted>(url);
        }

        internal Excepted SendRequest<Excepted>(string url, MethodsType method = MethodsType.GET,
            Dictionary<string, string> query = null, object objectToSend = null, ICustomDeserializer<Excepted> customDeserializer = null)
        {
            SendRequestAndGetResponse(method, url, query, objectToSend);

            if (customDeserializer == null)
                return TryGetResponse<Excepted>(client);
            else
                return TryGetResponseWithCustomDeserializer<Excepted>(client, customDeserializer);
        }

        internal dynamic SendRequest(string url, MethodsType method = MethodsType.GET,
            Dictionary<string, string> query = null, object objectToSend = null)
        {
            SendRequestAndGetResponse(method, url, query, objectToSend);

            return TryGetResponseDynamic(client);
        }

        internal bool ResponceHasSuccesStatusCode()
        {
            return client.ResponseHasSuccessStatusCode;
        }

        internal void AddQueryParam(string key, string value)
        {
            query.Add(key, value);
        }

        void SendRequestAndGetResponse(MethodsType method, string url, Dictionary<string, string> query = null, object objectToSend = null)
        {
            if(method != MethodsType.POST)
                client = new RestClient(url);
            else
                client = new RestClient(url, "application/x-www-form-urlencoded");

            Dictionary<string, string> newQuery = AddTwoDictionary(query, this.query);

            string bodyString = AddQueryAndAutorize(method, newQuery, objectToSend);

            if (bodyString == string.Empty)
                client.Send(method);
            else
               client.Send(method, bodyString, false);
        }

        Dictionary<T, Q> AddTwoDictionary<T, Q>(Dictionary<T, Q> first, Dictionary<T, Q> second)
        {
            Dictionary<T, Q> output;

            if (first != null)
                output = first;
            else if (second != null)
                output = second;
            else
                output = new Dictionary<T, Q>();

            if(second != null && first != null)
                foreach(KeyValuePair<T, Q> item in second)
                {
                    if (!output.ContainsKey(item.Key))
                        output.Add(item.Key, item.Value);
                }

            return output;
        }

        string AddQueryAndAutorize(MethodsType method, Dictionary<string, string> query = null, object objectBody = null)
        {
            //client.AddOwnHeaderToRequest("Content-Type", "application/x-www-form-urlencoded");

            // TODO change exception to UnautorizedClientException;
            if (autorization == Autorization.NONE)
            {
                client.AddQuery(query);
            }
            else if (autorization == Autorization.MARKET)
            {
                if (!session.IsMarketAutorized)
                    throw new Exception("Client is unautorized, use SetAutorizationData() method for autorize client, " +
                        "method required public api key.");

                client.AddQuery(query);
                client.AddOwnHeaderToRequest("X-MBX-APIKEY", session.PublicKey);
            }
            else if (autorization == Autorization.TRADING)
            {
                if (!session.IsTradingAutorized)
                    throw new Exception("Client is unautorized, use SetAutorizationData() method for autorize client, " +
                        "method required public and private api key.");

                client.AddOwnHeaderToRequest("X-MBX-APIKEY", session.PublicKey);

                string totalParmas = string.Empty;

                if(query != null)
                    totalParmas += client.AddQuery(query);
                
                string body = string.Empty;
                if (objectBody != null)
                {
                    body = ObjectToQueryConverter.Convert(objectBody);

                    if(method != MethodsType.POST)
                        totalParmas += client.AddStringToEndOfQuery("&" + body);
                    else
                        totalParmas += body;
                }
                else
                {
                    if (method == MethodsType.POST)
                    {
                        body = "null";
                        totalParmas += body;
                    }
                }

                if (query != null)
                    client.AddStringToEndOfQuery("&signature=" + HashManager.HashHMACHex(session.PrivateKey, totalParmas.Substring(1)));
                else
                    client.AddStringToEndOfQuery("?signature=" + HashManager.HashHMACHex(session.PrivateKey, totalParmas.Substring(1)));

                if (method == MethodsType.POST)
                    return body;
            }

            return "";
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

        Expected TryGetResponseWithCustomDeserializer<Expected>(RestClient rc, ICustomDeserializer<Expected> customDeserializer)
        {
            string response = rc.GetResponseToString;

            return customDeserializer.Deserialize(response);
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
