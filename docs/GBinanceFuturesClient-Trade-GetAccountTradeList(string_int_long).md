#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetAccountTradeList(string, int, long) Method
Get account trade list. WeightL 5.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.AccountTradeItem> GetAccountTradeList(string symbol, int limit=500, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetAccountTradeList(string_int_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTradeList(string_int_long)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of item, default: 500, max: 1000  
  
<a name='GBinanceFuturesClient-Trade-GetAccountTradeList(string_int_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[AccountTradeItem](./GBinanceFuturesClient-Model-Trade-AccountTradeItem.md 'GBinanceFuturesClient.Model.Trade.AccountTradeItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of orders  
