using System;
using System.Runtime.Serialization;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Rate limit exception, throw when server was code return 429 (rate limit) or 418 (ip ban).
    /// </summary>
    [Serializable]
    public class RateLimitException : Exception
    {
        private int code { get; set; }
        private bool exceedingRateLimit { get; set; } = false;
        private bool ban { get; set; } = false;

        /// <summary>
        /// Server error code.
        /// </summary>
        public int Code { get => code; }

        /// <summary>
        /// Exceeding rate limit
        /// </summary>
        public bool IsExceedingRateLimitError { get => exceedingRateLimit; }

        /// <summary>
        /// Is ban for ip (wait 2/3 minute to send new resuest)
        /// </summary>
        public bool IsIpBanError { get => ban; }

        internal RateLimitException() : base() { }

        internal RateLimitException(string message) : base(message){ }

        internal RateLimitException(int code, string message) : base(message)
        {
            this.code = code;
        }

        internal RateLimitException(int code, string message, bool isExceedingRateLimit = false, bool isBan = false) : base(message)
        {
            this.code = code;
            this.exceedingRateLimit = isExceedingRateLimit;
            this.ban = isBan;
        }

        internal RateLimitException(int code, string message, Exception innerException) : base(message, innerException)
        {
            this.code = code;
        }

        /// <summary>
        /// Convert exception object to string.
        /// </summary>
        /// <returns>Return string, format: "ErrorMessageException : msg: " + Message + ", code: " + code</returns>
        public override string ToString()
        {
            return "RateLimitException: message: " + Message + ", code: " + code + "(" + (ban == false? "rate limit" : "ban") + ")";
        }
    }
}
