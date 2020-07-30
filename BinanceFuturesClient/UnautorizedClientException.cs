using System;
using System.Runtime.Serialization;

namespace GBinanceFuturesClient
{
    /// <summary>
    /// Unautorized client exception, throw when client is unautorized to send request in autorized method.
    /// </summary>
    [Serializable]
    public class UnautorizedClientException : System.Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public UnautorizedClientException() : base() { }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public UnautorizedClientException(string message) : base(message){ }

        /// <summary>
        /// Constructor with error code, error message and exception stack.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception stack.</param>
        public UnautorizedClientException(string message, Exception innerException) : base(message, innerException)
        { }

        /// <summary>
        /// Convert exception object to string.
        /// </summary>
        /// <returns>Return string, format: "ErrorMessageException : msg: " + Message + ", code: " + code</returns>
        public override string ToString()
        {
            return "UnautorizedClientException: message: " + Message;
        }
    }
}
