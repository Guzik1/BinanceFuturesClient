#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetOrder(string, string, long) Method
Get order info using custom client order identificator. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo GetOrder(string symbol, string clientOrderId, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetOrder(string_string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-GetOrder(string_string_long)-clientOrderId'></a>
`clientOrderId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Client order identificator  
  
<a name='GBinanceFuturesClient-Trade-GetOrder(string_string_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order information object  
