#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetPositionMarginChangeHistory(string, long, long, int, int, long) Method
Get postion margin change history. Weight: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.PostionMarginChangeHistoryItem> GetPositionMarginChangeHistory(string symbol, long startTime, long endTime, int type, int limit=500, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-startTime'></a>
`startTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Start time from start get history items in unix milisecond  
  
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-endTime'></a>
`endTime` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
End time to end get history items in unix milisecond  
  
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-type'></a>
`type` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Operation type: 1: Add position margin，2: Reduce position margin  
  
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-limit'></a>
`limit` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Limit of item, default: 500, max: 1000  
  
<a name='GBinanceFuturesClient-Trade-GetPositionMarginChangeHistory(string_long_long_int_int_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[PostionMarginChangeHistoryItem](./GBinanceFuturesClient-Model-Trade-PostionMarginChangeHistoryItem.md 'GBinanceFuturesClient.Model.Trade.PostionMarginChangeHistoryItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of history items  
