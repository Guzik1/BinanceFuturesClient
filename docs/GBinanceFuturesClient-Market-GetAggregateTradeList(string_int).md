#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetAggregateTradeList(string, int) Method
Get compressed, aggregate trades.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.AggregateTradeItem> GetAggregateTradeList(string symbol, int limit=500);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetAggregateTradeList(string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetAggregateTradeList(string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of trades, default 500.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[AggregateTradeItem](./GBinanceFuturesClient-Model-Market-AggregateTradeItem.md 'GBinanceFuturesClient.Model.Market.AggregateTradeItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of aggregate trade items.  
