#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.ChangeLeverage(string, int, long) Method
Change user's initial leverage of specific symbol market. Weight: 1.  
```csharp
public GBinanceFuturesClient.Model.Trade.ChangeLeverageInfo ChangeLeverage(string symbol, int leverage, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-ChangeLeverage(string_int_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-ChangeLeverage(string_int_long)-leverage'></a>
`leverage` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Target initial leverage: int from 1 to 125  
  
<a name='GBinanceFuturesClient-Trade-ChangeLeverage(string_int_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[ChangeLeverageInfo](./GBinanceFuturesClient-Model-Trade-ChangeLeverageInfo.md 'GBinanceFuturesClient.Model.Trade.ChangeLeverageInfo')  
Changed leverage info  
