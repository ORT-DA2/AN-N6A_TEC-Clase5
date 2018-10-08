# AN-N6A_TEC-Clase5

```
dotnet ef migrations add Initial -p CityInfo.DataAccess -s CityInfo.API

dotnet ef database update  -p CityInfo.DataAccess -s CityInfo.API
```

```
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="2.1.1" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="2.1.1" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="2.1.1" />
  </ItemGroup>

  ...

<ItemGroup>
  <None Update="appsettings.json">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

[publish command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21)

```
dotnet publish -c Release CityInfo.API/CityInfo.API.csproj
```

git add --force folder

[Hosting Bundle](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.1#install-the-net-core-hosting-bundle)

https://www.microsoft.com/net/download/thank-you/dotnet-runtime-2.1.5-windows-hosting-bundle-installer

IIS APPPOOL\siteName
