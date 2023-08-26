# Dependency Injection Configuration
Provide support for configuring [ServiceCollection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) via [IConfiguration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json)

### Usage

Install the package via nuget:

```shell
dotnet add package DependencyInjection.Configuration
```

Configuration can be read using the extension `FromConfiguration()`:

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

IServiceCollection services = new ServiceCollection();

services.FromConfiguration(configuration);
```

Services definition is read from `appsettings.json`:

```json
{
  "Services": {
    "Collection": [
      {
        "ServiceType": "Sample.Interfaces.IRepository, Sample",
        "ImplementationType": "Sample.Impl.Repository, Sample",
        "Lifetime": "Scoped"
      },
      {
        "ServiceType": "Sample.Interfaces.IService, Sample",
        "ImplementationType": "Sample.Impl.Service, Sample"
      }
    ]
  }
}
```

The JSON location of services definition can be changed in options:

```csharp
var options = new DependencyInjectionConfigurationOptions
{
    Path = "SomeOtherPath"
};

services.FromConfiguration(configuration, options);
```


Per registration the following parameters can be set

- `ServiceType`: type to register
- `ImplementationType`: type that implements `ServiceType`
- `Lifetime`: lifetime of the registration. Values are taken from enum [Lifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime)