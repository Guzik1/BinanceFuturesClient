﻿using RestApiClient;
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
            return Tools.GetFromServer<ExchangeInfo>(Config.ApiPublicMarketUrl + "exchangeInfo");
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

        List<AggregateTradeItem> SendGetAggregateTradeListRequest(string symbol, long startTime = 0, long endTime = 0, long fromId = 0, int limit = 500)
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

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<AggregateTradeItem>>(client);
        }
        #endregion

        #region GetCandleStick
        //TODO: add interval enum.
        /// <summary>
        /// Get candle stick data.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="interval">One candle time interval.</param>
        /// <param name="limit">Limit of trades, default 500, max 1500.</param>
        /// <returns>List of candles.</returns>
        public List<CandlestickData> GetCandleStick(string symbol, string interval, int limit = 500)
        {
            return SendGetCandleStickRequest(symbol, interval, limit: limit);
        }

        /// <summary>
        /// Get candle stick data.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="interval">One candle time interval.</param>
        /// <param name="startTime">Get candles from start time.</param>
        /// <param name="endTime">Get candles to start time.</param>
        /// <param name="limit">Limit of trades, default 500, max 1500.</param>
        /// <returns>List of candles.</returns>
        public List<CandlestickData> GetCandleStick(string symbol, string interval, long startTime, long endTime, int limit = 500)
        {
            return SendGetCandleStickRequest(symbol, interval, startTime, endTime, limit);
        }

        List<CandlestickData> SendGetCandleStickRequest(string symbol, string interval, long startTime = 0, long endTime = 0, int limit = 500)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "klines");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            query.Add("interval", interval);

            if (limit != 500)
                query.Add("limit", limit.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            client.AddQuery(query);
            client.SendGET();

            List<List<string>> list = Tools.TryGetResponse<List<List<string>>>(client);

            List<CandlestickData> candles = new List<CandlestickData>();
            for (int i = 0; i < list.Count; i++)
                candles.Add(new CandlestickData(list[i]));

            return candles;
        }
        #endregion

        #region GetMarkPrice
        /// <summary>
        /// Get mark price. Weight: 1.
        /// </summary>
        /// <returns>List of mark price object.</returns>
        public List<MarkPriceResponse> GetMarkPrice()
        {
            return Tools.GetFromServer<List<MarkPriceResponse>>(Config.ApiPublicMarketUrl + "premiumIndex");
        }

        /// <summary>
        /// Get mark price. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <returns>Mark price object.</returns>
        public MarkPriceResponse GetMarkPrice(string symbol)
        {
            return Tools.GetFromServer<MarkPriceResponse>(Config.ApiPublicMarketUrl + "premiumIndex", symbol);
        }
        #endregion

        #region GetFundingRateHistory
        /// <summary>
        /// Get historicial funding rate. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit of result object, default 100, max 1000.</param>
        /// <returns>List of funding rate histori items.</returns>
        public List<FundingRateHistory> GetFundingRateHistory(string symbol, int limit = 100)
        {
            return SendGetFundingRateHistoryRequest(symbol, limit: limit);
        }

        /// <summary>
        /// Get historicial funding rate. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="startTime">Start getting result from start time.</param>
        /// <param name="endTime">End getting result to end time.</param>
        /// <param name="limit">Limit of result object, default 100, max 1000.</param>
        /// <returns>List of funding rate histori items.</returns>
        public List<FundingRateHistory> GetFundingRateHistory(string symbol, long startTime, long endTime, int limit = 100)
        {
            return SendGetFundingRateHistoryRequest(symbol, startTime, endTime, limit);
        }

        List<FundingRateHistory> SendGetFundingRateHistoryRequest(string symbol, long startTime = 0, long endTime = 0, int limit = 100)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "fundingRate");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            
            if(startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", startTime.ToString());

            if (limit != 100)
                query.Add("limit", limit.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<FundingRateHistory>>(client);
        }
        #endregion

        #region 24hTickerPriceChangeStatisctic
        /// <summary>
        /// Get ticker, 24 hours statistic. Weight: 40
        /// </summary>
        /// <returns>24 hours statistic ticker.</returns>
        public List<Ticker24h> Get24hTicker()
        {
            return Tools.GetFromServer<List<Ticker24h>>(Config.ApiPublicMarketUrl + "ticker/24hr");
        }

        /// <summary>
        /// Get ticker, 24 hours statistic. Weight: 1
        /// </summary>
        /// <param name="symbol">Currency pair symbol.</param>
        /// <returns>24 hours statistic ticker.</returns>
        public Ticker24h Get24hTicker(string symbol)
        {
            return Tools.GetFromServer<Ticker24h>(Config.ApiPublicMarketUrl + "ticker/24hr", symbol);
        }
        #endregion

        #region GetSymbolPriceTicker
        /// <summary>
        /// Get symbol price ticker. Weight 2.
        /// </summary>
        /// <returns>List of all symbols price ticker.</returns>
        public List<PriceTicker> GetSymbolPriceTicker()
        {
            return Tools.GetFromServer<List<PriceTicker>>(Config.ApiPublicMarketUrl + "ticker/price");
        }

        /// <summary>
        /// Get symbol price ticker. Weight 1.
        /// </summary>
        /// <returns>Symbol price ticker object.</returns>
        public PriceTicker GetSymbolPriceTicker(string symbol)
        {
            return Tools.GetFromServer<PriceTicker>(Config.ApiPublicMarketUrl + "ticker/price", symbol);
        }
        #endregion

        #region SymbolOrderBookTicker
        /// <summary>
        /// Get best price/qty on the order book for symbols. Weight: 2
        /// </summary>
        /// <returns>List of order book ticker objects.</returns>
        public List<OrderBookTicker> GetOrderBookTicker()
        {
            return Tools.GetFromServer<List<OrderBookTicker>>(Config.ApiPublicMarketUrl + "ticker/bookTicker");
        }

        /// <summary>
        /// Get best price/qty on the order book for a single symbols. Weight: 1
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Order book ticker object,</returns>
        public OrderBookTicker GetOrderBookTicker(string symbol)
        {
            return Tools.GetFromServer<OrderBookTicker>(Config.ApiPublicMarketUrl + "ticker/bookTicker", symbol);
        }
        #endregion

        #region GetAllLiquidationOrders
        /// <summary>
        /// Get all liquidation orders. Weight: 5.
        /// </summary>
        /// <param name="symbol">Currency pair symbol code.</param>
        /// <param name="limit">Limit of resault, default 100, nax 1000.</param>
        /// <returns>List of liquidation order.</returns>
        public List<LiquidationOrder> GetLiquidationOrders(string symbol = "", int limit = 100)
        {
             return SendGetLiquidationOrdersAndGetResponse(symbol, limit);
        }

        /// <summary>
        /// Get all liquidation orders. Weight: 5.
        /// </summary>
        /// <param name="startTime">Get order from start time (in unixtimestamp ).</param>
        /// <param name="endTime">Get order to end time (in unixtimestamp).</param>
        /// <param name="symbol">Currency pair symbol code.</param>
        /// <param name="limit">Limit of resault, default 100, nax 1000.</param>
        /// <returns></returns>
        public List<LiquidationOrder> GetLiquidationOrders(long startTime, long endTime, string symbol = "", int limit = 100)
        {
            return SendGetLiquidationOrdersAndGetResponse(symbol, limit, startTime, endTime);
        }

        List<LiquidationOrder> SendGetLiquidationOrdersAndGetResponse(string symbol = "", int limit = 100, long startTime = 0, long endTime = 0)
        {
            RestClient client = new RestClient(Config.ApiPublicMarketUrl + "allForceOrders");
            Dictionary<string, string> query = new Dictionary<string, string>();

            if (symbol != "")
                query.Add("symbol", symbol);

            if (limit != 100)
                query.Add("limit", limit.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            client.AddQuery(query);
            client.SendGET();

            return Tools.TryGetResponse<List<LiquidationOrder>>(client);
        }
        #endregion

    }
}
