#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Market](./GBinanceFuturesClient-Market.md 'GBinanceFuturesClient.Market')
## Market.GetLiquidationOrders(long, long, string, int) Method
Get all liquidation orders. Weight: 5.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Market.LiquidationOrder> GetLiquidationOrders(long startTime, long endTime, string symbol="", int limit=100);
```
#### Parameters
<a name='GBinanceFuturesClient-Market-GetLiquidationOrders(long_long_string_int)-startTime'></a>
`startTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Get order from start time (in unixtimestamp ).  
  
<a name='GBinanceFuturesClient-Market-GetLiquidationOrders(long_long_string_int)-endTime'></a>
`endTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Get order to end time (in unixtimestamp).  
  
<a name='GBinanceFuturesClient-Market-GetLiquidationOrders(long_long_string_int)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair symbol code.  
  
<a name='GBinanceFuturesClient-Market-GetLiquidationOrders(long_long_string_int)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of resault, default 100, nax 1000.  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[LiquidationOrder](./GBinanceFuturesClient-Model-Market-LiquidationOrder.md 'GBinanceFuturesClient.Model.Market.LiquidationOrder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
  
