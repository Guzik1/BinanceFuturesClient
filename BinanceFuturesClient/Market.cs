using RestApiClient;
using System;
using System.Collections.Generic;
using System.Text;
using BinanceFuturesClient.Model.Market;

namespace BinanceFuturesClient
{
    /// <summary>
    /// Binance futures market endpoint.
    /// </summary>
    public class Market
    {
        /// <summary>
        /// Ping to server. Check connection to rest api. Weight: 1.
        /// </summary>
        /// <returns>True if server response is ok, or false else.</returns>
        public bool Ping()
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "ping");
            client.SendGET();

            return client.ResponseHasSuccessStatusCode;
        }

        /// <summary>
        /// Get server time in unix milisecond timestamp. Weight: 1.
        /// </summary>
        /// <returns>Unix milisecond server time.</returns>
        public long GetServerTime()
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "time");
            client.SendGET();

            dynamic response = Tools.TryGetResponseDynamic(client);

            return response["serverTime"];
        }

        /// <summary>
        /// Get exchange info for all futures market. Weight: 1.
        /// </summary>
        /// <returns>Exchange info object.</returns>
        public ExchangeInfo GetExchangeInfo()
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "exchangeInfo");
            client.SendGET();

            return Tools.TryGetResponse<ExchangeInfo>(client);
        }

        /// <summary>
        /// Get order book from api. Weight: 10
        /// </summary>
        /// <param name="symbol">Symbol of currence pair.</param>
        /// <returns>OrderBook object. Return 500 ask and 500 bid offers.</returns>
        public OrderBook GetOrderBook(string symbol)
        {
            return SendGetOrderBookRequest(symbol);
        }

        /// <summary>
        /// Get order book from api.
        /// </summary>
        /// <param name="symbol">Symbol of currence pair.</param>
        /// <param name="limit">Limit of transaction, available: 5, 10, 20, 50 (weight 2), 100 (weight 5), 500 (weight 10), 1000 (weight 20).</param>
        /// <returns>OrderBook object.</returns>
        public OrderBook GetOrderBook(string symbol, int limit)
        {
            return SendGetOrderBookRequest(symbol, limit);
        }

        OrderBook SendGetOrderBookRequest(string symbol, int limit = 0)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "depth");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if(limit != 0)
                query.Add("limit", limit.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<OrderBook>(client);
        }

        
    }
}
