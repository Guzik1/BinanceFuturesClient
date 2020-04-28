using System;
using System.Runtime.Serialization;

namespace GBinanceFuturesClient
{
    [Serializable]
    public class ErrorMessageException : System.Exception
    {
        private int code { get; set; }
        public int Code { get => code; }

        public ErrorMessageException() : base() { }

        public ErrorMessageException(string message) : base(message){ }

        public ErrorMessageException(int code, string message) : base(message)
        {
            this.code = code;
        }

        public ErrorMessageException(int code, string message, Exception innerException) : base(message, innerException)
        {
            this.code = code;
        }

        public override string ToString()
        {
            return "ErrorMessageException : msg: " + Message + ", code: " + code;
        }
    }
}
