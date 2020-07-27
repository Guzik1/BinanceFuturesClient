#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelOrder(string, long, long) Method
Candel order using order id.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo CancelOrder(string symbol, long orderId, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_long_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_long_long)-orderId'></a>
`orderId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Order identificator (long)  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_long_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Recv window time in unix milisecond, default 5000.  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order info object, this same for NewOrder and GetOrder request.  
