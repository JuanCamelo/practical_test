Estructura de Carpetas de Proyecto
==============================

- **Application/**
  - ApplicationProjectInformation.cs
- **Context/**
  - **DBContext/**
    - ApplicationContext.cs
  - **Entities/**
    - VistaCantidadProyectosDepartamento.cs
    - VistaDepartamentosProyecto.cs
    - VistaEmpleadoAsignadosProyecto.cs
    - VistaInformacionProyectosDepartamento.cs
- **Contract/**
  - IApplicationProjectInformation.cs
- **DI/**
  - DependenciInjecionProfile.cs
- **Helpers/**
  - CreateReponse.cs
- **Models/**
  - **Request/**
    - Options.cs
  - **Response/**
    - BaseModel.cs
    - CantidadProyectosDepartamento.cs
    - DepartamentosProyecto.cs
    - EmpleadoAsignadosProyecto.cs
    - InformacionProyectosDepartamento.cs
- **Repository/**
  - **Contract/**
    - IRepository.cs
  - Repository.cs
- **FuntionsLambda.cs**
- 
# Solución Desplegada en AWS Lambda

Este proyecto ha sido desplegado en AWS Lambda y está disponible para su acceso en línea. Puedes acceder a la solución a través de la siguiente URL:

- **URL de Acceso:** [https://n0wrl6t1zb.execute-api.us-east-1.amazonaws.com/Prod/](https://n0wrl6t1zb.execute-api.us-east-1.amazonaws.com/Prod/)

# Manual de Usuario

Para obtener instrucciones detalladas sobre cómo utilizar esta solución, consulta el **Manual de Usuario** incluido en este repositorio. con el nombre "UserManual.pdf".

Esperamos que esta información sea útil para comprender la estructura del proyecto, acceder a la solución.
