#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetRectenTradesList(string, int) Method
Get recent trade list. Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.TradeItem> GetRectenTradesList(string symbol, int limit=500);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetRectenTradesList(string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetRectenTradesList(string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit max 1000, default 500.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TradeItem](./GBinanceFuturesClient-Model-Market-TradeItem.md 'GBinanceFuturesClient.Model.Market.TradeItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of trades.  
