#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetOrderBook(string, int) Method
Get order book from api.  
```csharp
public GBinanceFuturesClient.Model.Market.OrderBook GetOrderBook(string symbol, int limit);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetOrderBook(string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Symbol of currence pair.  
  
<a name='GBinanceFuturesClient-Market-GetOrderBook(string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of transaction, available: 5, 10, 20, 50 (weight 2), 100 (weight 5), 500 (weight 10), 1000 (weight 20).  
  
#### Returns
[OrderBook](./GBinanceFuturesClient-Model-Market-OrderBook.md 'GBinanceFuturesClient.Model.Market.OrderBook')  
OrderBook object.  
