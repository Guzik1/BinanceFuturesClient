using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Data model for response on <see cref="GBinanceFuturesClient.Trade.GetAccountTransactionHistory(string, long, long, int, int)"/> request.
    /// </summary>
    public class AccountTransactionHistory
    {
        /// <summary>
        /// List of transaction history rows.
        /// </summary>
        public List<AccountTransactionHistoryItem> Rows { get; set; }

        /// <summary>
        /// List of transaction history rows count.
        /// </summary>
        public int Total { get; set; }
    }

    /// <summary>
    /// Account transaction history item.
    /// </summary>
    public class AccountTransactionHistoryItem
    {
        /// <summary>
        /// Currency code.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Transaction identificator.
        /// </summary>
        [JsonProperty("trandId")]
        public int TrandId { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Unix milisecond timestaml.
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Transactio status. one of PENDING (pending to execution), CONFIRMED (successfully transfered), FAILED (execution failed, nothing happened to your account)
        /// </summary>
        public string Status { get; set; }
    }
}
