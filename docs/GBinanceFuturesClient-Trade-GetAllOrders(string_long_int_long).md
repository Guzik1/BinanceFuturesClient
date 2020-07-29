#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetAllOrders(string, long, int, long) Method
Get all orders from account. Weight: 5.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.OrderInfo> GetAllOrders(string symbol, long orderId, int limit=500, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetAllOrders(string_long_int_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-GetAllOrders(string_long_int_long)-orderId'></a>
`orderId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Order identificator, If orderId is set, it will get orders >= that orderId. Otherwise most recent orders are returned.  
  
<a name='GBinanceFuturesClient-Trade-GetAllOrders(string_long_int_long)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of order, default: 500, max: 1000  
  
<a name='GBinanceFuturesClient-Trade-GetAllOrders(string_long_int_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of order information object  
