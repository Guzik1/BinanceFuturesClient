#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.PlaceMultipleOrders(System.Collections.Generic.List&lt;GBinanceFuturesClient.Model.Trade.NewOrderRequest&gt;, long) Method
Place multiple orders. Weight: 5.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse<GBinanceFuturesClient.Model.Trade.OrderInfo>> PlaceMultipleOrders(System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.NewOrderRequest> listOfNewOrder, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-PlaceMultipleOrders(System-Collections-Generic-List-GBinanceFuturesClient-Model-Trade-NewOrderRequest-_long)-listOfNewOrder'></a>
`listOfNewOrder` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[NewOrderRequest](./GBinanceFuturesClient-Model-Trade-NewOrderRequest.md 'GBinanceFuturesClient.Model.Trade.NewOrderRequest')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of orders  
  
<a name='GBinanceFuturesClient-Trade-PlaceMultipleOrders(System-Collections-Generic-List-GBinanceFuturesClient-Model-Trade-NewOrderRequest-_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;](./GBinanceFuturesClient-Model-Trade-ValidOrErrorResponse-ValidResponseType-.md 'GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;ValidResponseType&gt;')[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')[&gt;](./GBinanceFuturesClient-Model-Trade-ValidOrErrorResponse-ValidResponseType-.md 'GBinanceFuturesClient.Model.Trade.ValidOrErrorResponse&lt;ValidResponseType&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of valid or error response, containing response on order. Responses in the order of the list sent.  
