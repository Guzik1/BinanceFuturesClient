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

        /* Already unavailable in futures api.
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
        #endregion*/

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
        /// Change user's position mode (true for Hedge Mode or false for One-way Mode) on EVERY symbol. Weight: 1
        /// </summary>
        /// <param name="dualSidePosition">Set true for Hedge Mode mode, false for One-way Mode, default: false</param>
        /// <param name="recvWindow">Timing security, unix time milisecond. Specify the number of milliseconds after timestamp the request is valid for.</param>
        /// <returns>True if the changes was successful, false the change was invalid.</returns>
        public bool ChangePositionMode(bool dualSidePosition, long recvWindow = 5000)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("dualSidePosition", dualSidePosition.ToString().ToLower());
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

        #region Get Current Position Mode
        /// <summary>
        /// Get user's position mode (Hedge Mode or One-way Mode ) on EVERY symbol. Weight: 30.
        /// </summary>
        /// <returns>Return ture for " Hedge Mode" or false for "One-way Mode".</returns>
        public bool GetCurrentPositionMode()
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            dynamic response = manager.SendRequest(Config.ApiPublicUrl + "positionSide/dual");

            return response["dualSidePosition"];
        }
        #endregion

        #region Place New Order
        /// <summary>
        /// Place new order. Weight: 1.
        /// </summary>
        /// <param name="request">Order info object</param>
        /// <returns>Order information object</returns>
        public OrderInfo PlaceOrder(NewOrderRequest request)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.POST, objectToSend: request);
        }

        /// <summary>
        /// Place new order. Weight: 1.
        /// </summary>
        /// <param name="request">Order info object</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>Order information object</returns>
        public OrderInfo PlaceOrder(NewOrderRequest request, long recvWindow)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());

            if(recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.POST, objectToSend: request);
        }
        #endregion

        #region Place Multiple Orders
        /// <summary>
        /// Place multiple orders. Weight: 5.
        /// </summary>
        /// <param name="listOfNewOrder">List of orders</param>
        /// <returns>List of valid or error response, containing response on order. Responses in the order of the list sent.</returns>
        public List<ValidOrErrorResponse<OrderInfo>> PlaceMultipleOrders(List<NewOrderRequest> listOfNewOrder)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("batchOrders", JsonTools.SerializeAsJson(listOfNewOrder));

            return manager.SendRequest(Config.ApiPublicUrl + "batchOrders", MethodsType.POST, 
                customDeserializer: new MultipleOrderCustomDeserializer<OrderInfo>());
        }

        /// <summary>
        /// Place multiple orders. Weight: 5.
        /// </summary>
        /// <param name="listOfNewOrder">List of orders</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>List of valid or error response, containing response on order. Responses in the order of the list sent.</returns>
        public List<ValidOrErrorResponse<OrderInfo>> PlaceMultipleOrders(List<NewOrderRequest> listOfNewOrder, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("batchOrders", JsonTools.SerializeAsJson(listOfNewOrder));

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "batchOrders", MethodsType.POST,
                customDeserializer: new MultipleOrderCustomDeserializer<OrderInfo>());
        }
        #endregion

        #region QueryOrder
        /// <summary>
        /// Get order info using orderId. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderId">Order identificator</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>Order information object</returns>
        public OrderInfo GetOrder(string symbol, long orderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderId", orderId.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.GET);
        }

        /// <summary>
        /// Get order info using custom client order identificator. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="clientOrderId">Client order identificator</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>Order information object</returns>
        public OrderInfo GetOrder(string symbol, string clientOrderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("origClientOrderId", clientOrderId);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.GET);
        }
        #endregion

        #region Cancel Order
        /// <summary>
        /// Candel order using order id.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderId">Order identificator (long)</param>
        /// <returns>Order info object, this same for NewOrder and GetOrder request.</returns>
        public OrderInfo CancelOrder(string symbol, long orderId)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderId", orderId.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.DELETE);
        }

        /// <summary>
        /// Candel order using order id.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="clientOrderId">Client custon order identificator (string)</param>
        /// <returns>Order info object, this same for NewOrder and GetOrder request.</returns>
        public OrderInfo CancelOrder(string symbol, string clientOrderId)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("origClientOrderId", clientOrderId);

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.DELETE);
        }

        /// <summary>
        /// Candel order using order id.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderId">Order identificator (long)</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>Order info object, this same for NewOrder and GetOrder request.</returns>
        public OrderInfo CancelOrder(string symbol, long orderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderId", orderId.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.DELETE);
        }

        /// <summary>
        /// Candel order using order id.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="clientOrderId">Client custon order identificator (string)</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>Order info object, this same for NewOrder and GetOrder request.</returns>
        public OrderInfo CancelOrder(string symbol, string clientOrderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("origClientOrderId", clientOrderId);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "order", MethodsType.DELETE);
        }
        #endregion

        #region Cancel all open orders
        /// <summary>
        /// Delete all open order on one symbol. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>Message object, with status code and message</returns>
        public Message CancelAllOpenOrders(string symbol, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());
            
            return manager.SendRequest<Message>(Config.ApiPublicUrl + "allOpenOrders", MethodsType.DELETE);
        }
        #endregion

        #region Cancel multiple orders
        /// <summary>
        /// Cancel multiple order, using order id list.  Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderIdList">List of order identificator to cancel</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>List of valid or error response, containing response on order. Responses in the order of the list sent.</returns>
        public List<ValidOrErrorResponse<OrderInfo>> CancelMultipleOrders(string symbol, List<long> orderIdList, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderIdList", JsonTools.SerializeAsJson(orderIdList));

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "batchOrders", MethodsType.DELETE,
                customDeserializer: new MultipleOrderCustomDeserializer<OrderInfo>());
        }

        /// <summary>
        /// Cancel multiple order, using custom client order identificator list. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="clientOrderIdList">List of client order identificator to cancel</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>List of valid or error response, containing response on order. Responses in the order of the list sent.</returns>
        public List<ValidOrErrorResponse<OrderInfo>> CancelMultipleOrders(string symbol, List<string> clientOrderIdList, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("origClientOrderIdList", JsonTools.SerializeAsJson(clientOrderIdList));

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "batchOrders", MethodsType.DELETE,
                customDeserializer: new MultipleOrderCustomDeserializer<OrderInfo>());
        }
        #endregion

        #region Auto-cancel all open orders
        /// <summary>
        /// Auto cancel all open orders using countdown. Weight: 10.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="countdownTimer">Countdown time in milisecond</param>
        /// <returns>Resonse object</returns>
        public AutoCancelAllOpenOrdersResponse AutoCancelAllOpenOrders(string symbol, long countdownTimer)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("countdownTime", countdownTimer.ToString());

            return manager.SendRequest<AutoCancelAllOpenOrdersResponse>(Config.ApiPublicUrl + "countdownCancelAll ", MethodsType.POST);
        }

        /// <summary>
        /// Auto cancel all open orders using countdown. Weight: 10.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="countdownTimer">Countdown time in milisecond</param>
        /// <param name="recvWindow">Recv window time in unix milisecond, default 5000.</param>
        /// <returns>Resonse object</returns>
        public object AutoCancelAllOpenOrders(string symbol, long countdownTimer, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("countdownTime", countdownTimer.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<AutoCancelAllOpenOrdersResponse>(Config.ApiPublicUrl + "countdownCancelAll ", MethodsType.POST);
        }
        #endregion

        #region Get query current open order
        /// <summary>
        /// Get current open order. Usind order id. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderId">Order identificator (long)</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>order information object</returns>
        public OrderInfo GetCurrentOpenOrder(string symbol, long orderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderId", orderId.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "openOrder", MethodsType.GET);
        }

        /// <summary>
        /// Get current open order. Usind order id. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="clientOrderId">Custom client order identificator (string)</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>order information object</returns>
        public OrderInfo GetCurrentOpenOrder(string symbol, string clientOrderId, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("origClientOrderId", clientOrderId);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest<OrderInfo>(Config.ApiPublicUrl + "openOrder", MethodsType.GET);
        }
        #endregion

        #region Get current all open orders
        /// <summary>
        /// Get current all open orders on one symbol. Weight: 1
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <returns>List of current open order information.</returns>
        public List<OrderInfo> GetAllOpenOrders(string symbol)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);

            return manager.SendRequest(Config.ApiPublicUrl + "openOrders", MethodsType.GET, customDeserializer: new SingleOrArrayCustromDeserializer<OrderInfo>());
        }

        /// <summary>
        /// Get current all open orders on one symbol. Weight: 1
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>List of current open order information.</returns>
        public List<OrderInfo> GetAllOpenOrders(string symbol, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "openOrders", MethodsType.GET, customDeserializer: new SingleOrArrayCustromDeserializer<OrderInfo>());
        }
        #endregion

        #region Get all orders
        /// <summary>
        /// Get all orders from account. Weight: 5.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="limit">Limit of order, default: 500, max: 1000</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>List of order information object</returns>
        public List<OrderInfo> GetAllOrders(string symbol, int limit = 500, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());
            
            if(limit != 500)
                manager.AddQueryParam("limit", limit.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "allOrders", MethodsType.GET, customDeserializer: new SingleOrArrayCustromDeserializer<OrderInfo>());
        }

        /// <summary>
        /// Get all orders from account. Weight: 5.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="orderId">Order identificator, If orderId is set, it will get orders >= that orderId. Otherwise most recent orders are returned.</param>
        /// <param name="limit">Limit of order, default: 500, max: 1000</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>List of order information object</returns>
        public List<OrderInfo> GetAllOrders(string symbol, long orderId, int limit = 500, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("orderId", orderId.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            if (limit != 500)
                manager.AddQueryParam("limit", limit.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "allOrders", MethodsType.GET, customDeserializer: new SingleOrArrayCustromDeserializer<OrderInfo>());
        }

        /// <summary>
        /// Get all orders from account. Weight: 5.
        /// </summary>
        /// <param name="symbol">Currency pair code</param>
        /// <param name="startTime">Get all order from startTime in unix milisecond</param>
        /// <param name="endTime">Get all order to endTime, in uxni milisecond</param>
        /// <param name="limit">Limit of order, default: 500, max: 1000</param>
        /// <param name="recvWindow">Custom recvWindow, default: 5000</param>
        /// <returns>List of order information object</returns>
        public List<OrderInfo> GetAllOrders(string symbol, long startTime, long endTime, int limit = 500, long recvWindow = 5000)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);
            manager.AddQueryParam("startTime", startTime.ToString());
            manager.AddQueryParam("endTime", endTime.ToString());

            if (recvWindow != 5000)
                manager.AddQueryParam("recvWindow", recvWindow.ToString());

            if (limit != 500)
                manager.AddQueryParam("limit", limit.ToString());

            return manager.SendRequest(Config.ApiPublicUrl + "allOrders", MethodsType.GET, customDeserializer: new SingleOrArrayCustromDeserializer<OrderInfo>());
        }
        #endregion



        // ... //
        #region Get Notional and Leverage Brackets
        /// <summary>
        /// Get Notional and Leverage Brackets. Weight: 1.
        /// </summary>
        /// <returns>List of brackets.</returns>
        public List<NationalAndLeverageBrackets> GetNationalBrackets()
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING);
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());

            return manager.SendRequest<List<NationalAndLeverageBrackets>>(Config.ApiPublicUrl + "leverageBracket");
        }

        /// <summary>
        /// Get Notional and Leverage Brackets. Weight: 1.
        /// </summary>
        /// <param name="symbol">Currency pair code.</param>
        /// <returns>Brackets object.</returns>
        public NationalAndLeverageBrackets GetNationalBrackets(string symbol)
        {
            RequestManager manager = new RequestManager(session, Autorization.TRADING); ;
            manager.AddQueryParam("timestamp", Tools.NowUnixTime().ToString());
            manager.AddQueryParam("symbol", symbol);

            return manager.SendRequest<NationalAndLeverageBrackets>(Config.ApiPublicUrl + "leverageBracket");
        }
        #endregion
    }
}
