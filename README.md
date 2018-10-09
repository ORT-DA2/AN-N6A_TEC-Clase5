# AN-N6A_TEC-Clase5

## Publish

 ### Scripts (con y sin datos)
Teniendo en el servidor sql, la version final de la base podemos generar los scripts para la entrega(archivos .sql).

En SQL SM Studio:
* btn-derecho sobre la base->Tareas->Generar Script
Next->Next->Avanzado -> scroll down -> la última opción de las setting General podemos especificar
solo esquema o esquema y datos

### Generación del publish
[publish command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21)

```
dotnet publish -c Release CityInfo.API/CityInfo.API.csproj
```

Una vez ejecutado, en consola, nos indica el path de la carpeta publish.
El contenido de la misma va ser el que vamos a deployar en IIS

TIP: Dado que la carpeta contiene archivos con extensiones como .dll que pueden estar siendo excluidas por .gitingore, se recomienda subir la carpeta publish a master utilizando:
```
git add --force folder
```

### Instalar Hosting Bundle
  [MSDocs - host and deploy
  ](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.1#install-the-net-core-hosting-bundle)

  [Hosting Bundle download link](https://www.microsoft.com/net/download/thank-you/dotnet-runtime-2.1.5-windows-hosting-bundle-installer)

### Deploy en IIS

#### Crear carpeta en inetpub
En el disco donde se encuentre instalado Windows, en el primer nivel, encontrarán la carpeta inetpub.
Crear una carpeta (en este caso mySite) en el path indicado a continuacion:
```
C:\inetpub\wwwroot\mySite
```

#### Crear Sitio en IIS

Abrimos el Administrador de Internet Information Services (IIS). Esto llegamos haciendo run de "inetmgr" o buscando en Windows

![Agregar nuevo sitio](/IIS_add_new.png)

![Opnciones del nuevo sitio](/IIS_options.png)


### Configuarción de usuario de IIS en SQL
Debemos agregar un login en sql

En SQL SM Studio:
Una vez conectados a la instancia sql, vemos en el Explorador:
Seguridad -> Nuevo -> Nuevo Inicio de Sesión

En nombre ingresamos: IIS APPPOOL\siteName  (el nombre que ingresamos en IIS)


Nos movemos a la pestaña Roles del Servidor para definir los permisos sobre las bases,
asignar:
 * dbcreator
 * sysadmin

### PUT/DELETE error 405
En caso de tener inconventientes con estas rutas, es necesario agregar en el web.config que es generado en el publish:

```
<system.webServer>

  <modules runAllManagedModulesForAllRequests="false">
    <remove name="WebDAVModule" />
  </modules>

</system.webServer>
```

[+ Info](https://www.ryadel.com/en/error-405-methods-not-allowed-asp-net-core-put-delete-requests/)
