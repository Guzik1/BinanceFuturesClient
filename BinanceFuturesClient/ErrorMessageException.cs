using System;
using System.Runtime.Serialization;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Error message exception, throw when server was return error message.
    /// </summary>
    [Serializable]
    public class ErrorMessageException : System.Exception
    {
        private int code { get; set; }

        /// <summary>
        /// Server error code.
        /// </summary>
        public int Code { get => code; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ErrorMessageException() : base() { }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public ErrorMessageException(string message) : base(message){ }

        /// <summary>
        /// Constructor with error code and message.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public ErrorMessageException(int code, string message) : base(message)
        {
            this.code = code;
        }

        /// <summary>
        /// Constructor with error code, error message and exception stack.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception stack.</param>
        public ErrorMessageException(int code, string message, Exception innerException) : base(message, innerException)
        {
            this.code = code;
        }

        /// <summary>
        /// Convert exception object to string.
        /// </summary>
        /// <returns>Return string, format: "ErrorMessageException : msg: " + Message + ", code: " + code</returns>
        public override string ToString()
        {
            return "ErrorMessageException : msg: " + Message + ", code: " + code;
        }
    }
}
