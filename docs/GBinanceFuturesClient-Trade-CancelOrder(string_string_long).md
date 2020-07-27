#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelOrder(string, string, long) Method
Candel order using order id.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo CancelOrder(string symbol, string clientOrderId, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_string_long)-clientOrderId'></a>
`clientOrderId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Client custon order identificator (string)  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_string_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Recv window time in unix milisecond, default 5000.  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order info object, this same for NewOrder and GetOrder request.  
