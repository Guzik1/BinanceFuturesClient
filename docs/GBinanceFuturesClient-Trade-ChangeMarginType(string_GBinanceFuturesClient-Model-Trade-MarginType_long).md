#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.ChangeMarginType(string, GBinanceFuturesClient.Model.Trade.MarginType, long) Method
Change margin type betwen two option. Weight: 1  
```csharp
public GBinanceFuturesClient.Model.Trade.Message ChangeMarginType(string symbol, GBinanceFuturesClient.Model.Trade.MarginType marginType, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-ChangeMarginType(string_GBinanceFuturesClient-Model-Trade-MarginType_long)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Currency pair code  
  
<a name='GBinanceFuturesClient-Trade-ChangeMarginType(string_GBinanceFuturesClient-Model-Trade-MarginType_long)-marginType'></a>
`marginType` [MarginType](./GBinanceFuturesClient-Model-Trade-MarginType.md 'GBinanceFuturesClient.Model.Trade.MarginType')  
Margin type: isolated or corssed  
  
<a name='GBinanceFuturesClient-Trade-ChangeMarginType(string_GBinanceFuturesClient-Model-Trade-MarginType_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Custom recvWindow, default: 5000  
  
#### Returns
[Message](./GBinanceFuturesClient-Model-Trade-Message.md 'GBinanceFuturesClient.Model.Trade.Message')  
Server response message  
