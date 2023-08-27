# Dependency Injection Configuration  ![Build status](https://github.com/lucadecamillis/dependency-injection-configuration/actions/workflows/ci.yml/badge.svg?branch=master) [![NuGet](https://img.shields.io/nuget/v/DependencyInjection.Configuration.svg)](https://www.nuget.org/packages/DependencyInjection.Configuration)

Provide support for configuring [ServiceCollection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) in [ASP.NET WebAPI](https://github.com/dotnet/aspnetcore) or via [IConfiguration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json)

## Installation

Install the package via nuget:

```shell
dotnet add package DependencyInjection.Configuration
```

## Web Api

Configuration is read using the extension `FromConfiguration()`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.FromConfiguration(builder.Configuration);
```

## `IConfiguration`

For console or WPF applications configuration can still be read using the extension `FromConfiguration()`:

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

IServiceCollection services = new ServiceCollection();

services.FromConfiguration(configuration);
```

## Definition

Services definition is read from `appsettings.json`:

```json
{
  "Services": {
    "Collection": [
      {
        "ServiceType": "Samples.Lib.Interfaces.IRepository, Samples.Lib",
        "ImplementationType": "Samples.Lib.Impl.Repository, Samples.Lib",
        "Lifetime": "Scoped"
      },
      {
        "ServiceType": "Samples.Lib.Interfaces.IService, Samples.Lib",
        "ImplementationType": "Samples.Lib.Impl.Service, Samples.Lib"
      },
      {
        "ServiceType": "Samples.Lib.Impl.Context, Samples.Lib",
        "Lifetime": "Singleton"
      },
      {
        "ServiceType": "Samples.Lib.Interfaces.IGenericService`1, Samples.Lib",
        "ImplementationType": "Samples.Lib.Impl.GenericService`1, Samples.Lib"
      }
    ]
  }
}
```

Per registration the following parameters can be set

- `ServiceType`: Assembly Qualified Name of the type to register (Required)
- `ImplementationType`: Assembly Qualified Name of the type that implements `ServiceType` (Optional)
- `Lifetime`: lifetime of the registration (Optional). Values are taken from enum [ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime). If not provided it defaults to `ServiceLifetime.Transient`

The JSON location of services definition can be changed in options:

```csharp
var options = new DependencyInjectionConfigurationOptions
{
    Path = "SomeOtherPath"
};

services.FromConfiguration(configuration, options);
```

For console or WebApi examples check out the samples directory.