using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Basic server response message object.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        public string Msg { get; set; }
    }
}
