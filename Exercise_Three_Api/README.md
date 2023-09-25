Estructura de Carpetas de Proyecto
==============================

- **Application/**
   - **Contract/**
     - ICurrencyHistoryService.cs
  - AppplicationtCurrenHistory.cs
- **Domain/**
  - **Contract/**
    - IHistoryQueryStrategy.cs
  - **Strategy/**
    - ConvertHistoryQuery.cs
    - LastYearHistoryQuery.cs
    - TimeseriesHistoryQuery.cs
- **DI/**
  - DependenciInjecionProfile.cs
- **GatewayCommon/**
  - **Services/**
     - BaseService.cs
- **Helpers/**
  - CreateReponse.cs
- **Models/**
  - CurrencyExchangeRateViewModel
  - CurrencyHistoryViewModel.cs  
- **Services/**
  - CurrencyHistoryService.cs
    
- **FuntionsLambda.cs**
- 
# Solución Desplegada en AWS Lambda

Este proyecto ha sido desplegado en AWS Lambda y está disponible para su acceso en línea. Puedes acceder a la solución a través de la siguiente URL:

- **URL de Acceso:** [https://1svxe8yzd4.execute-api.us-east-1.amazonaws.com/Prod](https://1svxe8yzd4.execute-api.us-east-1.amazonaws.com/Prod)

# Manual de Usuario

Para obtener instrucciones detalladas sobre cómo utilizar esta solución, consulta el **Manual de Usuario** incluido en este repositorio. con el nombre "UserManual.pdf".

Esperamos que esta información sea útil para comprender la estructura del proyecto, acceder a la solución.


