#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.PlaceOrder(GBinanceFuturesClient.Model.Trade.NewOrderRequest, long) Method
Place new order. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo PlaceOrder(GBinanceFuturesClient.Model.Trade.NewOrderRequest request, long recvWindow);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-PlaceOrder(GBinanceFuturesClient-Model-Trade-NewOrderRequest_long)-request'></a>
`request` [NewOrderRequest](./GBinanceFuturesClient-Model-Trade-NewOrderRequest.md 'GBinanceFuturesClient.Model.Trade.NewOrderRequest')  
Order info object  
  
<a name='GBinanceFuturesClient-Trade-PlaceOrder(GBinanceFuturesClient-Model-Trade-NewOrderRequest_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order information object  
