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
        /// Market api methods object.
        /// </summary>
        public Market Market { get; private set; }

        /// <summary>
        /// Default constructor, for unautorized client.
        /// </summary>
        public BinanceFuturesClient() {
            Inicjalize();
        }

        /// <summary>
        /// Constructor to set public and private keys for sercure client.
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
        public void SetAutorizationData(string publicKey, string privateKey)
        {
            session.Autorize(publicKey, privateKey);
        }

        void Inicjalize()
        {
            Market = new Market(session);
        }
    }
}
