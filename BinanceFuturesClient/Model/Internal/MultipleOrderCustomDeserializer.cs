using GBinanceFuturesClient.Internal;
using GBinanceFuturesClient.Model.Trade;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Internal
{
    internal class MultipleOrderCustomDeserializer<ValidType> : ICustomDeserializer<List<ValidOrErrorResponse<ValidType>>>
    {
        public List<ValidOrErrorResponse<ValidType>> Deserialize(string response)
        {
            List<object> responseDeserialized = JsonTools.DeserializeFromJson<List<object>>(response);
            List<ValidOrErrorResponse<ValidType>> output = new List<ValidOrErrorResponse<ValidType>>();

            for(int i = 0; i < responseDeserialized.Count; i++)
            {
                try
                {
                    ValidType validObject = (ValidType)responseDeserialized[i];
                    output.Add(new ValidOrErrorResponse<ValidType>(validObject));
                }
                catch (Exception) { // TODO: change exception to invalidCast or etc.
                    ErrorMessage errorObject = (ErrorMessage)responseDeserialized[i];
                    output.Add(new ValidOrErrorResponse<ValidType>(errorObject));
                }
            }

            return output;
        }
    }
}
