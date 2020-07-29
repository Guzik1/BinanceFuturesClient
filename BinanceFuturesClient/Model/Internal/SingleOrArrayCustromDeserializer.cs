using GBinanceFuturesClient.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Model.Internal
{
    internal class SingleOrArrayCustromDeserializer<T> : ICustomDeserializer<List<T>>
    {
        public List<T> Deserialize(string response)
        {
            List<T> responseDeserialized;

            if (response[0] == '[')
                responseDeserialized = JsonTools.DeserializeFromJson<List<T>>(response);
            else
            {
                responseDeserialized = new List<T>();
                responseDeserialized.Add(JsonTools.DeserializeFromJson<T>(response));
            }

            return responseDeserialized;
        }
    }
}
