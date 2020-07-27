#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelOrder(string, long) Method
Candel order using order id.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo CancelOrder(string symbol, long orderId);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_long)-orderId'></a>
`orderId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Order identificator (long)  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order info object, this same for NewOrder and GetOrder request.  
