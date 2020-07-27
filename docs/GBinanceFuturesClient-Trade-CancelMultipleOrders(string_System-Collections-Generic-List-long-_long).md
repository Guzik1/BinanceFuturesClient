#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelMultipleOrders(string, System.Collections.Generic.List&lt;long&gt;, long) Method
Cancel multiple order, using order id list.  Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse<GBinanceFuturesClient.Model.Trade.OrderInfo>> CancelMultipleOrders(string symbol, System.Collections.Generic.List<long> orderIdList, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelMultipleOrders(string_System-Collections-Generic-List-long-_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelMultipleOrders(string_System-Collections-Generic-List-long-_long)-orderIdList'></a>
`orderIdList` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of order identificator to cancel  
  
<a name='GBinanceFuturesClient-Trade-CancelMultipleOrders(string_System-Collections-Generic-List-long-_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Recv window time in unix milisecond, default 5000.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;](./GBinanceFuturesClient-Model-Trade-ValidOrErrorResponse-ValidResponseType-.md 'GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;ValidResponseType&gt;')[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')[&gt;](./GBinanceFuturesClient-Model-Trade-ValidOrErrorResponse-ValidResponseType-.md 'GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;ValidResponseType&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of valid or error response, containing response on order. Responses in the order of the list sent.  
