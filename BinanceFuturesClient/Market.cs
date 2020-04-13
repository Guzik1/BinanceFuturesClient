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
        #region Ping
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
        #endregion

        #region GetServerTime
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
        #endregion

        #region GetExchangeInfo
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
        #endregion

        #region GetOrderBook
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
        #endregion

        #region GetRectenTradesList
        /// <summary>
        /// Get recent trade list. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit max 1000, default 500.</param>
        /// <returns>List of trades.</returns>
        public List<TradeItem> GetRectenTradesList(string symbol, int limit = 500)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "trades");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if (limit != 0)
                query.Add("limit", limit.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<TradeItem>>(client);
        }
        #endregion

        #region GetOldTradesLookup
        /// <summary>
        /// Get old trades list.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit of trades, default 500.</param>
        /// <returns>List of trades data.</returns>
        public List<TradeItem> GetOldTradesLookup(string symbol, int limit = 500)
        {
            return SendGetOldTradesLookup(symbol, limit);
        }

        /// <summary>
        /// Get old trades list.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit of trades, default 500.</param>
        /// <param name="fromId">Start from identificator.</param>
        /// <returns>List of trades data.</returns>
        public List<TradeItem> GetOldTradesLookup(string symbol, long fromId, int limit = 500)
        {
            return SendGetOldTradesLookup(symbol, limit, fromId);
        }

        List<TradeItem> SendGetOldTradesLookup(string symbol, int limit = 500, long fromId = 0)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "historicalTrades");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if (limit != 500)
                query.Add("limit", limit.ToString());

            if (fromId != 0)
                query.Add("fromId", fromId.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<TradeItem>>(client);
        }
        #endregion

        #region GetAggredateTradeList
        /// <summary>
        /// Get compressed, aggregate trades. 
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit of trades, default 500.</param>
        /// <returns>List of aggregate trade items.</returns>
        public List<AggregateTradeItem> GetAggregateTradeList(string symbol, int limit = 500)
        {
            return SendGetAggregateTradeListRequest(symbol, limit: limit);
        }

        /// <summary>
        /// Get compressed, aggregate trades. 
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="fromId">Get form trade identificator.</param>
        /// <param name="limit">Limit of trades, default 500.</param>
        /// <returns>List of aggregate trade items.</returns>
        public List<AggregateTradeItem> GetAggregateTradeList(string symbol, long fromId, int limit = 500)
        {
            return SendGetAggregateTradeListRequest(symbol, fromId: fromId, limit: limit);
        }

        /// <summary>
        /// Get compressed, aggregate trades. 
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="startTime">Get trades from start time.</param>
        /// <param name="endTime">Get trades to end time.</param>
        /// <param name="fromId">Get form trade identificator.</param>
        /// <param name="limit">Limit of trades, default 500.</param>
        /// <returns>List of aggregate trade items.</returns>
        public List<AggregateTradeItem> GetAggregateTradeList(string symbol, long startTime, long endTime, long fromId = 0, int limit = 500)
        {
            return SendGetAggregateTradeListRequest(symbol, startTime, endTime, fromId, limit);
        }

        List<AggregateTradeItem> SendGetAggregateTradeListRequest(string symbol, long startTime = 0, long endTIme = 0, long fromId = 0, int limit = 500)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "aggTrades");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if (limit != 500)
                query.Add("limit", limit.ToString());

            if (fromId != 0)
                query.Add("fromId", fromId.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTIme != 0)
                query.Add("endTime", endTIme.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<AggregateTradeItem>>(client);
        }
        #endregion




    }
}
