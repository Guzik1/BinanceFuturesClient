#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.ChangeIsolatedPostionMargin(string, decimal, int, long) Method
Change isolated postion margin. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.ChangedIsolatedPostionMargin ChangeIsolatedPostionMargin(string symbol, decimal amount, int type, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-ChangeIsolatedPostionMargin(string_decimal_int_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-ChangeIsolatedPostionMargin(string_decimal_int_long)-amount'></a>
`amount` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
Change amount  
  
<a name='GBinanceFuturesClient-Trade-ChangeIsolatedPostionMargin(string_decimal_int_long)-type'></a>
`type` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Change type: 1: Add position margin，2: Reduce position margin  
  
<a name='GBinanceFuturesClient-Trade-ChangeIsolatedPostionMargin(string_decimal_int_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[ChangedIsolatedPostionMargin](./GBinanceFuturesClient-Model-Trade-ChangedIsolatedPostionMargin.md 'GBinanceFuturesClient.Model.Trade.ChangedIsolatedPostionMargin')  
Changed isolated postion margin object response  
