using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using RestApiClient;

namespace GBinanceFuturesClient.Inside
{
    /// <summary>
    /// Autenticate trade endpoint. Implement IAddOwnHeaderToRequest interface. Use be GRestApiClient.
    /// </summary>
    public class AutenticateTrade : IAddOwnHeaderToRequest
    {
        SessionData config;
        string query;

        internal AutenticateTrade(SessionData config, string query)
        {
            this.config = config;
            this.query = query;
        }

        /// <summary>
        /// Add headers to GET, PUT, DELETE methods. Use be GRestApiClient.
        /// </summary>
        /// <returns>Dictionary of header (keys and values).</returns>
        public Dictionary<string, string> AddOwnHeader()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-MBX-APIKEY", config.PublicKey);
            //headers.Add("signature", HashHMAC(config.PrivateKey, query)); //TODO rewerite to query last param.

            return headers;
        }

        /// <summary>
        /// Add headers to POST methods. Use be GRestApiClient.
        /// </summary>
        /// <returns>Dictionary of header (keys and values).</returns>
        public Dictionary<string, string> AddOwnHeaderPOST(object POSTDataToSend)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-MBX-APIKEY", config.PublicKey);
            
            return headers;
        }
    }
}
