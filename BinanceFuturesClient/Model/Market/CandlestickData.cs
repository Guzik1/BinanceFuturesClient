using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GBinanceFuturesClient.Model.Market
{
    /// <summary>
    /// Data model represent one candle.
    /// </summary>
    public class CandlestickData
    {
        /// <summary>
        /// Candle open time in unix milisecond timestamp.
        /// </summary>
        public long OpenTime { get; set; }

        /// <summary>
        /// Candle close time in unix milisecond timestamp.
        /// </summary>
        public long CloseTime { get; set; }

        /// <summary>
        /// Open candle price.
        /// </summary>
        public decimal OpenPrice { get; set; }

        /// <summary>
        /// High candle price.
        /// </summary>
        public decimal HighPrice { get; set; }

        /// <summary>
        /// Low candle price.
        /// </summary>
        public decimal LowPrice { get; set; }

        /// <summary>
        /// Close candle price.
        /// </summary>
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// Candle base currence volume.
        /// </summary>
        public decimal BaseVolume { get; set; }

        /// <summary>
        /// Candle Quote currence volume.
        /// </summary>
        public decimal QuoteVolume { get; set; }

        /// <summary>
        /// Number of trades count.
        /// </summary>
        public int TradesCount { get; set; }

        /// <summary>
        /// Taker buy base asset volume.
        /// </summary>
        public decimal TakerBuyBaseVolume { get; set; }

        /// <summary>
        /// Taker buy quote asset volume.
        /// </summary>
        public decimal TakerBuyQuoteVolume { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CandlestickData() { }

        internal CandlestickData(List<string> list)
        {
            CultureInfo cultures = new CultureInfo("en-US");

            OpenTime = long.Parse(list[0]);
            OpenPrice = Convert.ToDecimal(list[1], cultures);
            HighPrice = Convert.ToDecimal(list[2], cultures);
            LowPrice = Convert.ToDecimal(list[3], cultures);
            ClosePrice = Convert.ToDecimal(list[4], cultures);
            BaseVolume = Convert.ToDecimal(list[5], cultures);
            CloseTime = long.Parse(list[6]);
            QuoteVolume = Convert.ToDecimal(list[7], cultures);
            TradesCount = int.Parse(list[8]);
            TakerBuyBaseVolume = Convert.ToDecimal(list[9], cultures);
            TakerBuyQuoteVolume = Convert.ToDecimal(list[10], cultures);
        }
    }
}
