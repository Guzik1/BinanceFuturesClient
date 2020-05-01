using System;
using System.Collections.Generic;
using System.Text;
using GBinanceFuturesClient.Model.Market;
using GBinanceFuturesClient.Manager;
using GBinanceFuturesClient.Model.Internal;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Binance futures market endpoint.
    /// </summary>
    public partial class Market
    {
        SessionData session;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Market() { }

        internal Market(SessionData session)
        {
            this.session = session;
        }

        #region Ping
        /// <summary>
        /// Ping to server. Check connection to rest api. Weight: 1.
        /// </summary>
        /// <returns>True if server response is ok, or false else.</returns>
        public bool Ping()
        {
            RequestManager manager = new RequestManager(session, Autorization.NONE);
            manager.SendRequest(Config.ApiPublicMarketUrl + "ping");

            return manager.ResponceHasSuccesStatusCode();
        }
        #endregion

        #region Get server time
        /// <summary>
        /// Get server time in unix milisecond timestamp. Weight: 1.
        /// </summary>
        /// <returns>Unix milisecond server time.</returns>
        public long GetServerTime()
        {
            RequestManager manager = new RequestManager(session, Autorization.NONE);
            dynamic response = manager.SendRequest(Config.ApiPublicMarketUrl + "time");

            return response["serverTime"];
        }
        #endregion

        #region Get exchange info
        /// <summary>
        /// Get exchange info for all futures market. Weight: 1.
        /// </summary>
        /// <returns>Exchange info object.</returns>
        public ExchangeInfo GetExchangeInfo()
        {
            return RequestManager.GetFromServer<ExchangeInfo>(Config.ApiPublicMarketUrl + "exchangeInfo", session);

        }
        #endregion

        #region Get order book
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
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if(limit != 0)
                query.Add("limit", limit.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<OrderBook>(Config.ApiPublicMarketUrl + "depth", query: query);
        }
        #endregion

        #region Get recten trades list
        /// <summary>
        /// Get recent trade list. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="limit">Limit max 1000, default 500.</param>
        /// <returns>List of trades.</returns>
        public List<TradeItem> GetRectenTradesList(string symbol, int limit = 500)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if (limit != 0)
                query.Add("limit", limit.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<List<TradeItem>>(Config.ApiPublicMarketUrl + "trades", query: query);
        }
        #endregion

        #region Get old trades lookup
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
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            if (limit != 500)
                query.Add("limit", limit.ToString());

            if (fromId != 0)
                query.Add("fromId", fromId.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<List<TradeItem>>(Config.ApiPublicMarketUrl + "historicalTrades", query: query);
        }
        #endregion

        #region Get aggredate trade list
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

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<List<AggregateTradeItem>>(Config.ApiPublicMarketUrl + "aggTrades", query: query);
        }
        #endregion

        #region Get candle stick
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
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            query.Add("interval", interval);

            if (limit != 500)
                query.Add("limit", limit.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            List<List<string>> list = manager.SendRequest<List<List<string>>>(Config.ApiPublicMarketUrl + "klines", query: query);

            List<CandlestickData> candles = new List<CandlestickData>();
            for (int i = 0; i < list.Count; i++)
                candles.Add(new CandlestickData(list[i]));

            return candles;
        }
        #endregion

        #region Get mark price
        /// <summary>
        /// Get mark price. Weight: 1.
        /// </summary>
        /// <returns>List of mark price object.</returns>
        public List<MarkPriceResponse> GetMarkPrice()
        {
            return RequestManager.GetFromServer<List<MarkPriceResponse>>(Config.ApiPublicMarketUrl + "premiumIndex", session);
        }

        /// <summary>
        /// Get mark price. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <returns>Mark price object.</returns>
        public MarkPriceResponse GetMarkPrice(string symbol)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<MarkPriceResponse>(Config.ApiPublicMarketUrl + "premiumIndex", query: query);
        }
        #endregion

        #region Get funding rate history
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
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            
            if(startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", startTime.ToString());

            if (limit != 100)
                query.Add("limit", limit.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<List<FundingRateHistory>>(Config.ApiPublicMarketUrl + "fundingRate", query: query);
        }
        #endregion

        #region 24h ticker price change statisctic
        /// <summary>
        /// Get ticker, 24 hours statistic. Weight: 40
        /// </summary>
        /// <returns>24 hours statistic ticker.</returns>
        public List<Ticker24h> Get24hTicker()
        {
            return RequestManager.GetFromServer<List<Ticker24h>>(Config.ApiPublicMarketUrl + "ticker/24hr", session);
        }

        /// <summary>
        /// Get ticker, 24 hours statistic. Weight: 1
        /// </summary>
        /// <param name="symbol">Currency pair symbol.</param>
        /// <returns>24 hours statistic ticker.</returns>
        public Ticker24h Get24hTicker(string symbol)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<Ticker24h>(Config.ApiPublicMarketUrl + "ticker/24hr", query: query);
        }
        #endregion

        #region Get symbol price ticker
        /// <summary>
        /// Get symbol price ticker. Weight 2.
        /// </summary>
        /// <returns>List of all symbols price ticker.</returns>
        public List<PriceTicker> GetSymbolPriceTicker()
        {
            return RequestManager.GetFromServer<List<PriceTicker>>(Config.ApiPublicMarketUrl + "ticker/price", session);
        }

        /// <summary>
        /// Get symbol price ticker. Weight 1.
        /// </summary>
        /// <returns>Symbol price ticker object.</returns>
        public PriceTicker GetSymbolPriceTicker(string symbol)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<PriceTicker>(Config.ApiPublicMarketUrl + "ticker/price", query: query);
        }
        #endregion

        #region Symbol order book ticker
        /// <summary>
        /// Get best price/qty on the order book for symbols. Weight: 2
        /// </summary>
        /// <returns>List of order book ticker objects.</returns>
        public List<OrderBookTicker> GetOrderBookTicker()
        {
            return RequestManager.GetFromServer<List<OrderBookTicker>>(Config.ApiPublicMarketUrl + "ticker/bookTicker", session);
        }

        /// <summary>
        /// Get best price/qty on the order book for a single symbols. Weight: 1
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Order book ticker object,</returns>
        public OrderBookTicker GetOrderBookTicker(string symbol)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<OrderBookTicker>(Config.ApiPublicMarketUrl + "ticker/bookTicker", query: query);
        }
        #endregion

        #region Get all liquidation orders
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
            Dictionary<string, string> query = new Dictionary<string, string>();

            if (symbol != "")
                query.Add("symbol", symbol);

            if (limit != 100)
                query.Add("limit", limit.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<List<LiquidationOrder>>(Config.ApiPublicMarketUrl + "allForceOrders", query: query);
        }
        #endregion

        #region Get Open Interest
        /// <summary>
        /// Get present open interest of a specific symbol. 
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <returns>Open interest item object.</returns>
        public OpenInterestItem GetOpenInterest(string symbol)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);

            RequestManager manager = new RequestManager(session, Autorization.NONE);
            return manager.SendRequest<OpenInterestItem>(Config.ApiPublicMarketUrl + "openInterest", query: query);
        }
        #endregion
    }
}
