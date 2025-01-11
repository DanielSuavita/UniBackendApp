# UniBackendApp

Api Prueba técnica para el trabajo de Desarrollador .Net/Angular para Interrapidísimo. Hecho en .NET 9, SQL Server 2019 y Angular. Está compuesto de 2 soluciones:

**El Backend del Proyecto**

https://github.com/DanielSuavita/UniBackendApp

**El Frontend del Proyecto**

https://github.com/DanielSuavita/UniAppClient

## Prerrequisitos

Para configurarlo y dejarlo listo para ejecutarse se necesita lo siguiente:

- Visual Studio 2022.
- SDK .NET 9.
- SQL Server 2019.
- NodeJS para instalar las dependencias de Angular.

## Configuración

### Base de Datos

Se deben ejecutar los 2 scripts SQL dentro de la carpeta de Scripts en orden que se encuentran dentro del proyecto del Backend en la carpeta *src/scripts*.

Opcionalmente, la maquetación de la base de datos se puede visualizar con la extensión **ERD Editor** en **Visual Studio Code**, en el archivo que se encuentra en los Assets del proyecto de Angular, en la carpeta *src/assets/database.vuerd.json.*

### Aplicación Backend

Se debe descargar el código fuente de Github, abrirlo en Visual Studio 2022, restaurar los paquetes NuGet, compilar y ejecutar.

De forma alternativa se puede ejecutar en Visual Studio Code y en la terminal ejecutar lo siguientes comandos:

```powershell
dotnet restore
dotnet build
dotnet run --project src/Api
```

### Aplicación Frontend

Se debe descargar el código fuente de Github, abrirlo en Visual Studio Code, restaurar los paquetes NPM y ejecutar. Así se puede desde la terminal ubicándose sobre el proyecto ya descargado.

```powershell
npm i
ng serve -o
```