using System;
using System.Collections.Generic;
using System.Text;

namespace GBinanceFuturesClient.Internal
{
    internal interface ICustomDeserializer<ReturnType>
    {
        ReturnType Deserialize(string response);
    }
}
