#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetOrderBook(string) Method
Get order book from api. Weight: 10  
```csharp
public GBinanceFuturesClient.Model.Market.OrderBook GetOrderBook(string symbol);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetOrderBook(string)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Symbol of currence pair.  
  
#### Returns
[OrderBook](./GBinanceFuturesClient-Model-Market-OrderBook.md 'GBinanceFuturesClient.Model.Market.OrderBook')  
OrderBook object. Return 500 ask and 500 bid offers.  
