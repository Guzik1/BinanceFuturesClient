#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.AutoCancelAllOpenOrders(string, long, long) Method
Auto cancel all open orders using countdown. Weight: 10.  
```csharp
public object AutoCancelAllOpenOrders(string symbol, long countdownTimer, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-AutoCancelAllOpenOrders(string_long_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-AutoCancelAllOpenOrders(string_long_long)-countdownTimer'></a>
`countdownTimer` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Countdown time in milisecond  
  
<a name='GBinanceFuturesClient-Trade-AutoCancelAllOpenOrders(string_long_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Recv window time in unix milisecond, default 5000.  
  
#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Resonse object  
