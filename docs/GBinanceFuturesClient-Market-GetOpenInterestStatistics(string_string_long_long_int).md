#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetOpenInterestStatistics(string, string, long, long, int) Method
Get open interest statistics. Only the data of the latest 30 days is available. Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.OpenInterestStatistics> GetOpenInterestStatistics(string symbol, string period, long startTime, long endTime, int limit=30);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetOpenInterestStatistics(string_string_long_long_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetOpenInterestStatistics(string_string_long_long_int)-period'></a>
`period` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.  
  
<a name='GBinanceFuturesClient-Market-GetOpenInterestStatistics(string_string_long_long_int)-startTime'></a>
`startTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Get data from start time.  
  
<a name='GBinanceFuturesClient-Market-GetOpenInterestStatistics(string_string_long_long_int)-endTime'></a>
`endTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Get data to end time.  
  
<a name='GBinanceFuturesClient-Market-GetOpenInterestStatistics(string_string_long_long_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of result count, default 30, max 500. Optional  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[OpenInterestStatistics](./GBinanceFuturesClient-Model-Market-OpenInterestStatistics.md 'GBinanceFuturesClient.Model.Market.OpenInterestStatistics')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of open interest statistics objects.  
