using System;
using System.Collections.Generic;
using System.Text;
using RestApiClient;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Autenticate market endpoint. Implement IAddOwnHeaderToRequest interface. Use be GRestApiClient.
    /// </summary>
    public class AutenticateMarket : IAddOwnHeaderToRequest
    {
        private SessionData config;

        internal AutenticateMarket(SessionData config)
            => this.config = config;

        /// <summary>
        /// Add headers to GET, PUT, DELETE methods. Use be GRestApiClient.
        /// </summary>
        /// <returns>Dictionary of header (keys and values).</returns>
        public Dictionary<string, string> AddOwnHeader()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-MBX-APIKEY", config.PublicKey);

            return headers;
        }

        /// <summary>
        /// Add headers to POST methods. Use be GRestApiClient.
        /// </summary>
        /// <returns>Dictionary of header (keys and values).</returns>
        public Dictionary<string, string> AddOwnHeaderPOST(object POSTDataToSend)
        {
            throw new NotImplementedException();
        }
    }
}
