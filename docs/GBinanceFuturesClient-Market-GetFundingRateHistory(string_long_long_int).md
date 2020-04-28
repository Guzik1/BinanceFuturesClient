#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetFundingRateHistory(string, long, long, int) Method
Get historicial funding rate. Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.FundingRateHistory> GetFundingRateHistory(string symbol, long startTime, long endTime, int limit=100);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetFundingRateHistory(string_long_long_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetFundingRateHistory(string_long_long_int)-startTime'></a>
`startTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Start getting result from start time.  
  
<a name='GBinanceFuturesClient-Market-GetFundingRateHistory(string_long_long_int)-endTime'></a>
`endTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
End getting result to end time.  
  
<a name='GBinanceFuturesClient-Market-GetFundingRateHistory(string_long_long_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of result object, default 100, max 1000.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[FundingRateHistory](./GBinanceFuturesClient-Model-Market-FundingRateHistory.md 'GBinanceFuturesClient.Model.Market.FundingRateHistory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of funding rate histori items.  
