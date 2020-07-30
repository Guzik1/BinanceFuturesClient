using GBasicExchangeDefinitions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Account information is reponse on <see cref="GBinanceFuturesClient.Trade.GetAccountInformation()"/> and
    /// <see cref="GBinanceFuturesClient.Trade.GetAccountInformation(long)"/> requst.
    /// </summary>
    public class AccountInformation
    {
        /// <summary>
        /// Account commisssion tier 
        /// </summary>
        [JsonProperty("feeTier")]
        public int FeeTier { get; set; }

        /// <summary>
        /// true if can trade
        /// </summary>
        [JsonProperty("canTrade")]
        public bool CanTrade { get; set; }

        /// <summary>
        /// true if can transfer in asset
        /// </summary>
        [JsonProperty("canDeposit")]
        public bool CanDeposit { get; set; }

        /// <summary>
        /// true if can transfer out asset
        /// </summary>
        [JsonProperty("canWithdraw")]
        public bool CanWithdraw { get; set; }

        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        /// <summary>
        /// Total initial margin required with current mark price (useless with isolated positions)
        /// </summary>
        [JsonProperty("totalInitialMargin")]
        public decimal TotalInitialMargin { get; set; }

        /// <summary>
        /// Total maintenance margin required
        /// </summary>
        [JsonProperty("totalMaintMargin")]
        public decimal TotalMaintMargin { get; set; }

        /// <summary>
        /// Total wallet balance
        /// </summary>
        [JsonProperty("totalWalletBalance")]
        public decimal TotalWalletBalance { get; set; }

        /// <summary>
        /// Total unrealized profit
        /// </summary>
        [JsonProperty("totalUnrealizedProfit")]
        public decimal TotalUnrealizedProfit { get; set; }

        /// <summary>
        /// Total margin balance
        /// </summary>
        [JsonProperty("totalMarginBalance")]
        public decimal TotalMarginBalance { get; set; }

        /// <summary>
        /// Initial margin required for positions with current mark price
        /// </summary>
        [JsonProperty("totalPositionInitialMargin")]
        public decimal TotalPositionInitialMargin { get; set; }

        /// <summary>
        /// Initial margin required for open orders with current mark price
        /// </summary>
        [JsonProperty("totalOpenOrderInitialMargin")]
        public decimal TotalOpenOrderInitialMargin { get; set; }

        /// <summary>
        /// Crossed wallet balance
        /// </summary>
        [JsonProperty("totalCrossWalletBalance")]
        public decimal TotalCrossWalletBalance { get; set; }

        /// <summary>
        /// Unrealized profit of crossed positions
        /// </summary>
        [JsonProperty("totalCrossUnPnl")]
        public decimal TotalCrossUnPnl { get; set; }

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

        /// <summary>
        /// List of assets.
        /// </summary>
        public List<AssetInformationItem> Assets { get; set; }

        /// <summary>
        /// Positions of all sumbols in the market.
        /// </summary>
        public List<PositionInformationItem> Positions { get; set; }
    }

    /// <summary>
    /// Asset information item
    /// </summary>
    public class AssetInformationItem
    {
        /// <summary>
        /// Currency code
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Wallet balance
        /// </summary>
        [JsonProperty("walletBalance")]
        public decimal WalletBalance { get; set; }

        /// <summary>
        /// Unrealized profit
        /// </summary>
        [JsonProperty("unrealizedProfit")]
        public decimal UnrealizedProfit { get; set; }

        /// <summary>
        /// Margin balance
        /// </summary>
        [JsonProperty("marginBalance")]
        public decimal MarginBalance { get; set; }

        /// <summary>
        /// Maintenance margin required
        /// </summary>
        [JsonProperty("maintMargin")]
        public decimal MaintMargin { get; set; }

        /// <summary>
        /// Total initial margin required with current mark price
        /// </summary>
        [JsonProperty("initialMargin")]
        public decimal InitialMargin { get; set; }

        /// <summary>
        /// Initial margin required for positions with current mark price
        /// </summary>
        [JsonProperty("positionInitialMargin")]
        public decimal PositionInitialMargin { get; set; }

        /// <summary>
        /// Initial margin required for open orders with current mark price
        /// </summary>
        [JsonProperty("openOrderInitialMargin")]
        public decimal OpenOrderInitialMargin { get; set; }

        /// <summary>
        /// Crossed wallet balance
        /// </summary>
        [JsonProperty("crossWalletBalance")]
        public decimal CrossWalletBalance { get; set; }

        /// <summary>
        /// Unrealized profit of crossed positions
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

    /// <summary>
    /// Position information item
    /// </summary>
    public class PositionInformationItem
    {
        /// <summary>
        /// Currency pair code
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Initial margin required with current mark price
        /// </summary>
        [JsonProperty("initialMargin")]
        public int InitialMargin { get; set; }

        /// <summary>
        /// Maintenance margin required
        /// </summary>
        [JsonProperty("maintMargin")]
        public int MaintMargin { get; set; }

        /// <summary>
        /// Unrealized profit
        /// </summary>
        [JsonProperty("unrealizedProfit")]
        public decimal UnrealizedProfit { get; set; }

        /// <summary>
        /// Initial margin required for positions with current mark price
        /// </summary>
        [JsonProperty("positionInitialMargin")]
        public int PositionInitialMargin { get; set; }

        /// <summary>
        /// Initial margin required for open orders with current mark price
        /// </summary>
        [JsonProperty("openOrderInitialMargin")]
        public int OpenOrderInitialMargin { get; set; }

        /// <summary>
        /// Current initial leverage 
        /// </summary>
        public int Leverage { get; set; }

        /// <summary>
        /// True if the position is isolated
        /// </summary>
        public bool Isolated { get; set; }

        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonProperty("entryPrice")]
        public decimal EntryPrice { get; set; }

        /// <summary>
        /// Maximum available notional with current leverage
        /// </summary>
        [JsonProperty("maxNotional")]
        public decimal MaxNotional { get; set; }

        /// <summary>
        /// Position side
        /// </summary>
        [JsonProperty("positionSide")]
        public PositionSide PositionSide { get; set; }
    }
}
