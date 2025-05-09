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


**Consultas**
1. ¿Cómo tu implementación puede ser escalable a miles de 
transacciones?
Que las consultas esten descopladas a la capa de infrastructura permite que el almacenamiento sea escalado en caso de necesitarse

2. ¿Cómo tu implementación asegura el principio de 
idempotencia?
Las creaciones consultan a la base de datos si no se trata de un elemento repetido en los registros (en caso de no permitirlo), evitando que haya data publicada en las tablas. También se ha colocado a entidades validaciones para valores únicos en columnas.

3. ¿Cómo protegerías tus servicios para evitar ataques de 
Denegación de servicios, sql injection, CSRF?
El hecho de que el aplicativo sea en un ORM y no con sql directo ya crea un obstaculo para posibles atacantes asi como que las consultas son a través de LINQ que vienen a hacer querys parametrizados. También el hecho de que Los repositorios son la unica capa con acceso a los datos. Para evitar posibles ataques se puede considerar el uso de cabeceras de seguridad y control de cors y estrategias de rate limit. Aunque el uso de jwt ya de cierta forma controla los ataques de CSRF.

4. ¿Cuál sería tu estrategia para migrar un monolito a 
microservicios?
    1: Considerar los controladores y sus servicios que son independientes, que no dependan de otros como un proyecto individual y separar la logica.
    2:Centralizar la entrada de información con una api gateway
    3:Manejar una base de dato por cada nuevo proyecto independiente  

5. ¿Qué alternativas a la solución requerida propondrías para una 
solución escalable?

**CORS: Mejor control de quien pueda realizar las peticiones
**Comunicacion con n Bases de DATOS: Al tratarse de una arquitectura de microservicios es comun interactuar con mulitples bases de datos, lo que se sugiere en esos casos es el uso de una API GATEWAY que centralice la entrada y salida de la información y que esta sea la unica con acceso para que pueda realizarse las consideraciones de seguridad necesaria.
**Manejo de Colas para transacciones: Las transacciones si son multiples usuarios podrian generar cuellos de botella por lo que podría ser un valor agregado considerar tecnologias de colas como RABBITMQ




