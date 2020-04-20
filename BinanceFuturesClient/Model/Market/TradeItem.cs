using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Trade item model, for .
    /// </summary>
    public class TradeItem
    {
        /// <summary>
        /// Trade identificator.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Offer price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Offer quantity.
        /// </summary>
        public decimal Qty { get; set; }

        /// <summary>
        /// Quote offer quantity.
        /// </summary>
        public decimal QuoteQty { get; set; }

        /// <summary>
        /// Offer unit timestamp
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// Is buyer maker flag.
        /// </summary>
        public bool IsBuyerMaker { get; set; }
    }
}
