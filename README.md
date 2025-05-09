# 💼 Wallet API

**Wallet** es una API REST en clean architecture programa en Net Core 8. Utiliza Identity para manejo de tablas de sesión, autenticación con JWT, pruebas unitarias.
El manejo de entidades se hace mediante el ORM que proprociona EntityFrameworkCore.

**Estructura**
Wallet.sln
├── Wallet.API/ → API principal
│ └── Program.cs, Controllers.
├── Wallet.Application/
│ └── DTOs, Services, Interfaces (servicios)
├── Wallet.Domain/
│ └── Entities, Interfaces (repositorios).
├── Wallet.Infrastructure/ → Migraciones, repositorios, Logica Externa (jwt)
└── Wallet.Test/ → Proyecto de pruebas con xUnit
└── Pruebas unitarias y funcionales

**Requisitos**
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- (Opcional) Visual Studio 2022 o superior


**Consideraciones**
El proyecto genera archivos logs, asegurarse de que en la carpeta donde se inicie se tenga permisos de escritura.

Al descargar el proyecto se debe de ejecutar todas las migraciones pendientes. El ejecutable es el proyecto Wallet.API, sin embargo el fichero de migraciones se encuentra en la capa de Wallet.Infrastructure.

El proyecto tiene configurado para que en modo desarrollo se visualicen las APIs disponibles junto a sus schemas con SWAGGER. Asi mismo, el proyecto incluye un archivo llamado apis.json que muestra esta información en texto.

**Instrucciones**

Para iniciar el proyecto:
1. ejecutar las migraciones se debe ejecutar el siguiente comando

dotnet ef database update --project Wallet.Infrastructure --startup-project Wallet.API
2. seleccionar proyecto Wallet.API e iniciar.


Se sugiere limpiar y recompilar los proyectos antes de empezar a utilizar.
La cadena de conexión a la base de datos se encuentra en el appsettings.development.json


