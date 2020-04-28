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

        /// <summary>
        /// Default constructor
        /// </summary>
        public Trade() { }

        internal Trade(SessionData session)
        {
            this.session = session;
        }

        #region New Future Account Transfer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyToTransfer"></param>
        /// <param name="amount"></param>
        /// <param name="type">Type of transfer: 1: transfer from spot main account to future account,  
        /// 2: transfer from future account to spot main account</param>
        /// <returns>Transaction identificator.</returns>
        public string NewFundsTransfer(string currencyToTransfer, decimal amount, int type)
        {
            Tools.CheckAutorizatioWhenUnautorizedThrowException(session);

            RestClient client = new RestClient(Config.ApiAccountTransferAndHistoryUrl + "transfer");

            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("asset", currencyToTransfer);
            query.Add("amount", amount.ToString());
            query.Add("type", type.ToString());
            query.Add("timestamp", Tools.NowUnixTime().ToString());

            string queryString = client.AddQuery(query);
            client.AddOwnHeaderToRequest(new AutenticateTrade(session, queryString));
            client.SendPOST<object>(null);

            dynamic response = Tools.TryGetResponseDynamic(client);
            return response["tranId"];
        }
        #endregion
    }
}
