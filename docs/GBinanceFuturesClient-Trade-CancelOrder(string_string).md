#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelOrder(string, string) Method
Candel order using order id.  
```csharp
public GBinanceFuturesClient.Model.Trade.OrderInfo CancelOrder(string symbol, string clientOrderId);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_string)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelOrder(string_string)-clientOrderId'></a>
`clientOrderId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Client custon order identificator (string)  
  
#### Returns
[OrderInfo](./GBinanceFuturesClient-Model-Trade-OrderInfo.md 'GBinanceFuturesClient.Model.Trade.OrderInfo')  
Order info object, this same for NewOrder and GetOrder request.  
