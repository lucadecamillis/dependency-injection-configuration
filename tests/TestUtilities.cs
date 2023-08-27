using LdC.DependencyInjection.Configuration.Loader;
using LdC.DependencyInjection.Configuration.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace LdC.DependencyInjection.Configuration.Tests;

internal static class TestUtilities
{
    public static IServiceProvider LoadServiceProvider(params Schema.Service[] services)
    {
        var servicesObj = new Services { Collection = services.ToArray() };

        return LoadServiceProvider(servicesObj);
    }

    public static IServiceProvider LoadServiceProvider(Services services)
    {
        var serviceCollection = new ServiceCollection();

        ServiceCollectionLoader.LoadServices(serviceCollection, services, DependencyInjectionConfigurationOptions.Default);

        return serviceCollection.BuildServiceProvider();
    }

    public static Service CreateSchemaService(Type serviceType)
    {
        return new Service { ServiceType = serviceType.AssemblyQualifiedName };
    }

    public static Service CreateSchemaService(Type serviceType, Type implType)
    {
        return new Service { ServiceType = serviceType.AssemblyQualifiedName, ImplementationType = implType.AssemblyQualifiedName };
    }

    public static Service CreateSchemaFactory(Type serviceType, Type factoryType, string methodName)
    {
        var factory = new Factory { Type = factoryType.AssemblyQualifiedName, Method = methodName };
        
        return new Service { ServiceType = serviceType.AssemblyQualifiedName, Factory = factory };
    }
}