#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.AutoCancelAllOpenOrders(string, long) Method
Auto cancel all open orders using countdown. Weight: 10.  
```csharp
public GBinanceFuturesClient.Model.Trade.AutoCancelAllOpenOrdersResponse AutoCancelAllOpenOrders(string symbol, long countdownTimer);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-AutoCancelAllOpenOrders(string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-AutoCancelAllOpenOrders(string_long)-countdownTimer'></a>
`countdownTimer` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Countdown time in milisecond  
  
#### Returns
[AutoCancelAllOpenOrdersResponse](./GBinanceFuturesClient-Model-Trade-AutoCancelAllOpenOrdersResponse.md 'GBinanceFuturesClient.Model.Trade.AutoCancelAllOpenOrdersResponse')  
Resonse object  
