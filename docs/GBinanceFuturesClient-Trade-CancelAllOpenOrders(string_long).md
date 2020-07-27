#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.CancelAllOpenOrders(string, long) Method
Delete all open order on one symbol. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.Message CancelAllOpenOrders(string symbol, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-CancelAllOpenOrders(string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-CancelAllOpenOrders(string_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Recv window time in unix milisecond, default 5000.  
  
#### Returns
[Message](./GBinanceFuturesClient-Model-Trade-Message.md 'GBinanceFuturesClient.Model.Trade.Message')  
Message object, with status code and message  
