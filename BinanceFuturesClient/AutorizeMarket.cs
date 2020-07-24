using GBinanceFuturesClient.Manager;
using GBinanceFuturesClient.Model.Internal;
using GBinanceFuturesClient.Model.Market;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{
    public partial class Market
    {
        #region GetOpenInterestStatistics
        /// <summary>
        /// Get open interest statistics. If there is no limit of startime and endtime, it will return the value brfore the current time by default. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of open interest statistics objects.</returns>
        public List<OpenInterestStatistics> GetOpenInterestStatistics(string symbol, string period, int limit = 30)
        {
            return GetOpenInterestStatistics(symbol, period, 0, 0, limit);
        }

        /// <summary>
        /// Get open interest statistics. Only the data of the latest 30 days is available. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="startTime">Get data from start time.</param>
        /// <param name="endTime">Get data to end time.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of open interest statistics objects.</returns>
        public List<OpenInterestStatistics> GetOpenInterestStatistics(string symbol, string period, long startTime, long endTime, int limit = 30)
        {
            return SendGetStatisticOrRatoRequest<List<OpenInterestStatistics>>("openInterestHist", symbol, period, limit, startTime, endTime);
        }
        #endregion

        #region Get Top Trader Long/Short Ratio (Accounts)
        /// <summary>
        /// Get top trader long/short accounts ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortAccountsRatio(string symbol, string period, int limit = 30)
        {
            return GetTopTradeLongShortAccountsRatio(symbol, period, 0, 0, limit);
        }

        /// <summary>
        /// Get top trader long/short accounts ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Only the data of the latest 30 days is available. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortAccountsRatio(string symbol, string period, long startTime, long endTime, int limit = 30)
        {
            return SendGetStatisticOrRatoRequest<List<RatioItem>>("topLongShortAccountRatio", symbol, period, limit, startTime, endTime);
        }
        #endregion

        #region Get Top Trader Long/Short Ratio (Positions)
        /// <summary>
        /// Get top trader long/short positions ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortPositionsRatio(string symbol, string period, int limit = 30)
        {
            return GetTopTradeLongShortPositionsRatio(symbol, period, 0, 0, limit);
        }

        /// <summary>
        /// Get top trader long/short positions ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Only the data of the latest 30 days is available. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortPositionsRatio(string symbol, string period, long startTime, long endTime, int limit = 30)
        {
            return SendGetStatisticOrRatoRequest<List<RatioItem>>("topLongShortPositionRatio", symbol, period, limit, startTime, endTime);
        }
        #endregion

        #region Get Long/Short Ratio
        /// <summary>
        /// Get top trader long/short ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortRatio(string symbol, string period, int limit = 30)
        {
            return GetTopTradeLongShortRatio(symbol, period, 0, 0, limit);
        }

        /// <summary>
        /// Get top trader long/short ratio. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Only the data of the latest 30 days is available. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of ratio item objects.</returns>
        public List<RatioItem> GetTopTradeLongShortRatio(string symbol, string period, long startTime, long endTime, int limit = 30)
        {
            return SendGetStatisticOrRatoRequest<List<RatioItem>>("globalLongShortAccountRatio", symbol, period, limit, startTime, endTime);
        }
        #endregion

        #region Get Taker Buy/Sell Volume
        /// <summary>
        /// Get taker, buy/selll volume. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of buy sell volume objects.</returns>
        public List<BuySellVolume> GetTakerBuySellVolume(string symbol, string period, int limit = 30)
        {
            return GetTakerBuySellVolume(symbol, period, 0, 0, limit);
        }

        /// <summary>
        /// Get taker, buy/selll volume. If there is no limit of startime and endtime, it will return the value brfore the 
        /// current time by default. Only the data of the latest 30 days is available. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <param name="period">Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">Limit of result count, default 30, max 500. Optional</param>
        /// <returns>List of buy sell volume objects.</returns>
        public List<BuySellVolume> GetTakerBuySellVolume(string symbol, string period, long startTime, long endTime, int limit = 30)
        {
            return SendGetStatisticOrRatoRequest<List<BuySellVolume>>("takerlongshortRatio", symbol, period, limit, startTime, endTime);
        }
        #endregion

        #region Tools for ratio and volume requests (private)
        T SendGetStatisticOrRatoRequest<T>(string url, string symbol, string period, int limit = 30, long startTime = 0, long endTime = 0)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("symbol", symbol);
            query.Add("period", period);

            if (limit != 30)
                query.Add("limit", limit.ToString());

            if (startTime != 0)
                query.Add("startTime", startTime.ToString());

            if (endTime != 0)
                query.Add("endTime", endTime.ToString());

            RequestManager manager = new RequestManager(session, Autorization.MARKET);
            return manager.SendRequest<T>(Config.ApiFuturesDataUrl + url, query: query);
        }
        #endregion
    }
}
