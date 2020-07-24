#### [GBinanceFuturesClient](./index.md 'index')
### [GBinanceFuturesClient.Model.Trade](./GBinanceFuturesClient-Model-Trade.md 'GBinanceFuturesClient.Model.Trade').[NewOrderRequest](./GBinanceFuturesClient-Model-Trade-NewOrderRequest.md 'GBinanceFuturesClient.Model.Trade.NewOrderRequest')
## NewOrderRequest.SetLimitOrder(string, GBasicExchangeDefinitions.OrderSide, decimal, decimal, GBasicExchangeDefinitions.TimeInForce) Method
Create limit order request.  
```csharp
public void SetLimitOrder(string symbol, GBasicExchangeDefinitions.OrderSide side, decimal quantity, decimal price, GBasicExchangeDefinitions.TimeInForce timeInForce=GBasicExchangeDefinitions.TimeInForce.GTC);
```
#### Parameters
<a name='GBinanceFuturesClient-Model-Trade-NewOrderRequest-SetLimitOrder(string_GBasicExchangeDefinitions-OrderSide_decimal_decimal_GBasicExchangeDefinitions-TimeInForce)-symbol'></a>
`symbol` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Symbol string  
  
<a name='GBinanceFuturesClient-Model-Trade-NewOrderRequest-SetLimitOrder(string_GBasicExchangeDefinitions-OrderSide_decimal_decimal_GBasicExchangeDefinitions-TimeInForce)-side'></a>
`side` [GBasicExchangeDefinitions.OrderSide](https://docs.microsoft.com/en-us/dotnet/api/GBasicExchangeDefinitions.OrderSide 'GBasicExchangeDefinitions.OrderSide')  
Order side  
  
<a name='GBinanceFuturesClient-Model-Trade-NewOrderRequest-SetLimitOrder(string_GBasicExchangeDefinitions-OrderSide_decimal_decimal_GBasicExchangeDefinitions-TimeInForce)-quantity'></a>
`quantity` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
Order quantity  
  
<a name='GBinanceFuturesClient-Model-Trade-NewOrderRequest-SetLimitOrder(string_GBasicExchangeDefinitions-OrderSide_decimal_decimal_GBasicExchangeDefinitions-TimeInForce)-price'></a>
`price` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
Order price  
  
<a name='GBinanceFuturesClient-Model-Trade-NewOrderRequest-SetLimitOrder(string_GBasicExchangeDefinitions-OrderSide_decimal_decimal_GBasicExchangeDefinitions-TimeInForce)-timeInForce'></a>
`timeInForce` [GBasicExchangeDefinitions.TimeInForce](https://docs.microsoft.com/en-us/dotnet/api/GBasicExchangeDefinitions.TimeInForce 'GBasicExchangeDefinitions.TimeInForce')  
Time in force, default: GTC  
  
