#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetCandleStick(string, string, int) Method
Get candle stick data.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.CandlestickData> GetCandleStick(string symbol, string interval, int limit=500);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetCandleStick(string_string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code.  
  
<a name='GBinanceFuturesClient-Market-GetCandleStick(string_string_int)-interval'></a>
`interval` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
One candle time interval.  
  
<a name='GBinanceFuturesClient-Market-GetCandleStick(string_string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of trades, default 500, max 1500.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[CandlestickData](./GBinanceFuturesClient-Model-Market-CandlestickData.md 'GBinanceFuturesClient.Model.Market.CandlestickData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of candles.  
