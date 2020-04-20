using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BinanceFuturesClient
{
    /// <summary>
    /// Main of class, biance futures rest api client.
    /// </summary>
    public class BinanceFuturesClient
    {
        SessionData session;

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
        /// Constructor to set keys for sercure client.
        /// </summary>
        /// <param name="PublicKey">Public api key.</param>
        /// <param name="PrivateKey">Private api key.</param>
        public BinanceFuturesClient(string PublicKey, string PrivateKey) {
            Inicjalize();

            session = new SessionData(PublicKey, PrivateKey);
        }

        /// <summary>
        /// Set autorization data for autorize client.
        /// </summary>
        /// <param name="publicKey">Public api key.</param>
        /// <param name="privateKey">Private api key.</param>
        public void SetAutorizationData(string publicKey, string privateKey)
        {
            session.PublicKey = publicKey;
            session.PrivateKey = privateKey;
        }

        void Inicjalize()
        {
            Market = new Market(session);
        }
    }
}
