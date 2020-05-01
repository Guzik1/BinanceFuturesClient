#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetAccountTransactionHistory(string, long, long, int, int) Method
Get future account transaction history list. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.AccountTransactionHistory GetAccountTransactionHistory(string asset, long startTime, long endTime=0L, int current=1, int size=10);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetAccountTransactionHistory(string_long_long_int_int)-asset'></a>
`asset` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency code.  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTransactionHistory(string_long_long_int_int)-startTime'></a>
`startTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Unix timestamp start time.  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTransactionHistory(string_long_long_int_int)-endTime'></a>
`endTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Unix timestamp end time. Default 0 (when default don't send to server).  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTransactionHistory(string_long_long_int_int)-current'></a>
`current` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Current page number, default: 1.  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTransactionHistory(string_long_long_int_int)-size'></a>
`size` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of row count. default: 10, max: 100  
  
#### Returns
[AccountTransactionHistory](./GBinanceFuturesClient-Model-Trade-AccountTransactionHistory.md 'GBinanceFuturesClient.Model.Trade.AccountTransactionHistory')  
Account transaction history object.  
