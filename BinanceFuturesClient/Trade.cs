using GBinanceFuturesClient.Inside;
using GBinanceFuturesClient.Manager;
using GBinanceFuturesClient.Model.Internal;
using GBinanceFuturesClient.Model.Trade;
using RestApiClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient
{    
    /// <summary>
     /// Binance futures account/trade endpoints methods.
     /// </summary>
    public class Trade
    {
        SessionData session;

        internal Trade(SessionData session)
        {
            this.session = session;
        }

        #region New Future Account Transfer
        /// <summary>
        /// Transfer funds between futures and spot account. Unavailable in testnet. Weight: 5.
        /// </summary>
        /// <param name="currencyToTransfer">Currency code.</param>
        /// <param name="amount">Transfer amount.</param>
        /// <param name="type">Type of transfer: 1: transfer from spot main account to future account,  
        /// 2: transfer from future account to spot main account</param>
        /// <returns>Transaction identificator.</returns>
        public string NewFundsTransfer(string currencyToTransfer, decimal amount, int type)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("asset", currencyToTransfer);
            query.Add("amount", amount.ToString());
            query.Add("type", type.ToString());
            query.Add("timestamp", Tools.NowUnixTime().ToString());

            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            dynamic response = manager.SendRequest(Config.ApiAccountTransferAndHistoryUrl + "transfer", MethodsType.POST, query);

            return response["tranId"];
        }
        #endregion

        #region Get Future Account Transaction History List
        /// <summary>
        /// Get future account transaction history list. Unavailable in testnet. Weight: 1.
        /// </summary>
        /// <param name="asset">Currency code.</param>
        /// <param name="startTime">Unix timestamp start time.</param>
        /// <param name="endTime">Unix timestamp end time. Default 0 (when default don't send to server).</param>
        /// <param name="current">Current page number, default: 1.</param>
        /// <param name="size">Limit of row count. default: 10, max: 100</param>
        /// <returns>Account transaction history object.</returns>
        public AccountTransactionHistory GetAccountTransactionHistory(string asset, long startTime, long endTime = 0, int current = 1, int size = 10)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("asset", asset);
            query.Add("startTime", startTime.ToString());
            query.Add("timestamp", Tools.NowUnixTime().ToString());

            if(endTime != 0)
                query.Add("endTime", endTime.ToString());

            if (current != 1)
                query.Add("current", current.ToString());

            if (size != 10)
                query.Add("size", size.ToString());

            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            return manager.SendRequest<AccountTransactionHistory>(Config.ApiAccountTransferAndHistoryUrl + "transfer", query: query);
        }
        #endregion

        #region Change Position Mode
        /// <summary>
        /// Change user's position mode (Hedge Mode or One-way Mode) on EVERY symbol. Weight: 1
        /// </summary>
        /// <param name="dualSidePosition">Set true for Hedge Mode mode, false for One-way Mode</param>
        /// <param name="recvWindow">Timing security, unix time milisecond. Specify the number of milliseconds after timestamp the request is valid for.</param>
        /// <returns>True if the changes was successful, false the change was invalid.</returns>
        public bool ChangePositionMode(bool dualSidePosition, long recvWindow = 5000)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("dualSidePosition", dualSidePosition.ToString());
            query.Add("timestamp", Tools.NowUnixTime().ToString());

            if(recvWindow != 5000)
                query.Add("recvWindow", recvWindow.ToString());

            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            dynamic response = manager.SendRequest(Config.ApiPublicUrl + "positionSide/dual", MethodsType.POST, query);

            if (response["code"] == 200 && response["msg"] == "success")
                return true;
            else
                return false;
        }
        #endregion
    }
}
