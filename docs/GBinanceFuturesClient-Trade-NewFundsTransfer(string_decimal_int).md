#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient](./GBinanceFuturesClient.md 'GBinanceFuturesClient').[Trade](./GBinanceFuturesClient-Trade.md 'GBinanceFuturesClient.Trade')
## Trade.NewFundsTransfer(string, decimal, int) Method
Transfer funds between futures and spot account.  
```csharp
public string NewFundsTransfer(string currencyToTransfer, decimal amount, int type);
```
#### Parameters
<a name='GBinanceFuturesClient-Trade-NewFundsTransfer(string_decimal_int)-currencyToTransfer'></a>
`currencyToTransfer` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
  
<a name='GBinanceFuturesClient-Trade-NewFundsTransfer(string_decimal_int)-amount'></a>
`amount` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
  
  
<a name='GBinanceFuturesClient-Trade-NewFundsTransfer(string_decimal_int)-type'></a>
`type` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Type of transfer: 1: transfer from spot main account to future account,    
            2: transfer from future account to spot main account  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Transaction identificator.  
