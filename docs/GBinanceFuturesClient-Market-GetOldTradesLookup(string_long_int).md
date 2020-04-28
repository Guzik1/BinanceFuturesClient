#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetOldTradesLookup(string, long, int) Method
Get old trades list.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.TradeItem> GetOldTradesLookup(string symbol, long fromId, int limit=500);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetOldTradesLookup(string_long_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetOldTradesLookup(string_long_int)-fromId'></a>
`fromId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Start from identificator.  
  
<a name='GBinanceFuturesClient-Market-GetOldTradesLookup(string_long_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of trades, default 500.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TradeItem](./GBinanceFuturesClient-Model-Market-TradeItem.md 'GBinanceFuturesClient.Model.Market.TradeItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of trades data.  
