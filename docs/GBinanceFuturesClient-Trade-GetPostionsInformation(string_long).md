#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.GetPostionsInformation(string, long) Method
Get postion information. Wieght: 1.  
```csharp
public System.Collections.Generic.List<GBinanceFuturesClient.Model.Trade.PositionInforamtionItem> GetPostionsInformation(string symbol, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-GetPostionsInformation(string_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-GetPostionsInformation(string_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[PositionInforamtionItem](./GBinanceFuturesClient-Model-Trade-PositionInforamtionItem.md 'GBinanceFuturesClient.Model.Trade.PositionInforamtionItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
List of positions information items  
