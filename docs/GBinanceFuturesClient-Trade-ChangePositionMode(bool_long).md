#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.ChangePositionMode(bool, long) Method
Change user's position mode (true for Hedge Mode or false for One-way Mode) on EVERY symbol. Weight: 1  
```csharp
public bool ChangePositionMode(bool dualSidePosition, long recvWindow=5000L);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-ChangePositionMode(bool_long)-dualSidePosition'></a>
`dualSidePosition` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Set true for Hedge Mode mode, false for One-way Mode, default: false  
  
<a name='GBinanceFuturesClient-Trade-ChangePositionMode(bool_long)-recvWindow'></a>
`recvWindow` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
Timing security, unix time milisecond. Specify the number of milliseconds after timestamp the request is valid for.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the changes was successful, false the change was invalid.  
