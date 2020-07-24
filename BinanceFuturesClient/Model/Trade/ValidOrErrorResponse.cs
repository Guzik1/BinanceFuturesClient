using GBinanceFuturesClient.Model.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Trade
{
    /// <summary>
    /// Valid or error response class, Use for <see cref="GBinanceFuturesClient.Trade.PlaceMultipleOrders(List{NewOrderRequest})"/> 
    /// and <see cref="GBinanceFuturesClient.Trade.PlaceMultipleOrders(List{NewOrderRequest}, long)"/> request.
    /// </summary>
    /// <typeparam name="ValidResponseType">Dynamic valid type</typeparam>
    public class ValidOrErrorResponse<ValidResponseType>
    {
        /// <summary>
        /// Valid response object. Null if response have errors. Use IsValid propetry to check if the answer is correct.
        /// </summary>
        public ValidResponseType ValidResponse;

        /// <summary>
        /// Error response object. Null if response is valid. Use IsValid propetry to check if the answer is incorrect.
        /// </summary>
        public ErrorMessage ErrorResponse;

        /// <summary>
        /// True if the response is valid, for error response false.
        /// </summary>
        public bool IsValid;

        internal ValidOrErrorResponse() { }

        internal ValidOrErrorResponse(ValidResponseType validResponse)
        {
            ValidResponse = validResponse;
            IsValid = true;
        }

        internal ValidOrErrorResponse(ErrorMessage errorResponse)
        {
            ErrorResponse = errorResponse;
            IsValid = false;
        }
    }
}
