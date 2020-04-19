﻿using System;
using System.Collections.Generic;
using System.Text;
using RestApiClient;

namespace BinanceFuturesClient
{
    public class AutenticateMarket : IAddOwnHeaderToRequest
    {
        private SessionData config;

        internal AutenticateMarket(SessionData config)
            => this.config = config;

        public Dictionary<string, string> AddOwnHeader()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-MBX-APIKEY", config.PublicApiKey);

            return headers;
        }

        public Dictionary<string, string> AddOwnHeaderPOST(object POSTDataToSend)
        {
            throw new NotImplementedException();
        }
    }
}
