using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Income types enum
    /// </summary>
    public enum IncomeType
    {
        /// <summary>Transfer</summary>
        TRANSFER,

        /// <summary>Welcome bonus</summary>
        WELCOME_BONUS,

        /// <summary>Realized PNL</summary>
        REALIZED_PNL,

        /// <summary>Funding fee</summary>
        FUNDING_FEE,

        /// <summary>Commission</summary>
        COMMISSION,

        /// <summary>Insurance clear</summary>
        INSURANCE_CLEAR
    }
}
