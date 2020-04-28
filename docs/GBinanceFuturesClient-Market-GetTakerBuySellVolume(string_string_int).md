#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetTakerBuySellVolume(string, string, int) Method
Get taker, buy/selll volume. If there is no limit of startime and endtime, it will return the value brfore the   
current time by default. Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.BuySellVolume> GetTakerBuySellVolume(string symbol, string period, int limit=30);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetTakerBuySellVolume(string_string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetTakerBuySellVolume(string_string_int)-period'></a>
`period` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Peroid, available: 5m, 15m, 30m, 1h, 2h, 4h, 6h, 12h, 1d.  
  
<a name='GBinanceFuturesClient-Market-GetTakerBuySellVolume(string_string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of result count, default 30, max 500. Optional  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[BuySellVolume](./GBinanceFuturesClient-Model-Market-BuySellVolume.md 'GBinanceFuturesClient.Model.Market.BuySellVolume')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of buy sell volume objects.  
