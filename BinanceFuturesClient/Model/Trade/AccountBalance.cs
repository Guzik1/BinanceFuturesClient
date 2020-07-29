using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    public class AccountBalance
    {
        /// <summary>
        /// Unique account code
        /// </summary>
        [JsonProperty("accountAlias")]
        public string AccountAlias { get; set; }

        /// <summary>
        /// Asset name
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Wallet ballande
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Crossed wallet balance
        /// </summary>
        [JsonProperty("crossWalletBalance")]
        public decimal CrossWalletBalance { get; set; }

        /// <summary>
        /// Unrealized profit or loss of crossed positions
        /// </summary>
        [JsonProperty("crossUnPnl")]
        public decimal CrossUnPnl { get; set; }

        /// <summary>
        /// Available balance
        /// </summary>
        [JsonProperty("availableBalance")]
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// Maximum amount for transfer out
        /// </summary>
        [JsonProperty("maxWithdrawAmount")]
        public decimal MaxWithdrawAmount { get; set; }
    }
}
