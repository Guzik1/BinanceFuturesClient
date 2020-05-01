using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Main of class, biance futures rest api client.
    /// </summary>
    public class BinanceFuturesClient
    {
        SessionData session = new SessionData();

        /// <summary>
        /// Market endpoints. Market api methods object.
        /// </summary>
        public Market Market { get; private set; }

        /// <summary>
        /// Trade/Account endpoints. All trade api methods.
        /// </summary>
        public Trade Trade { get; private set; }

        /// <summary>
        /// Default constructor, for unautorized client.
        /// </summary>
        public BinanceFuturesClient() {
            Inicjalize();
        }

        /// <summary>
        /// Constructor to set public keys for sercure client, use for market endpoint.
        /// </summary>
        /// <param name="publicKey">Public api key.</param>
        public BinanceFuturesClient(string publicKey)
        {
            Inicjalize();
            SetAutorizationData(publicKey);
        }

        /// <summary>
        /// Constructor to set public and private keys for sercure client, use for trading endpoint.
        /// </summary>
        /// <param name="publicKey">Public api key.</param>
        /// <param name="privateKey">Private api key.</param>
        public BinanceFuturesClient(string publicKey, string privateKey) {
            Inicjalize();
            SetAutorizationData(publicKey, privateKey);
        }

        /// <summary>
        /// Set autorization data for autorize client.
        /// </summary>
        /// <param name="publicKey">Public api key.</param>
        /// <param name="privateKey">Private api key.</param>
        public void SetAutorizationData(string publicKey, string privateKey = "")
        {
            session.Autorize(publicKey, privateKey);
        }

        /// <summary>
        /// Use testnet for own app testing.
        /// </summary>
        /// <param name="use">True for use testnet, false for disable testneta and set norlmal url address.</param>
        public void UseTestnet(bool use)
        {
            Config.UseTestnet(use);
        }

        void Inicjalize()
        {
            Market = new Market(session);
            Trade = new Trade(session);
        }
    }
}
