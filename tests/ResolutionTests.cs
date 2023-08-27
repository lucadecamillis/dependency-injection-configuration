using LdC.DependencyInjection.Configuration.Loader;
using LdC.DependencyInjection.Configuration.Schema;
using Microsoft.Extensions.DependencyInjection;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;

namespace LdC.DependencyInjection.Configuration.Tests;

public class ResolutionTests
{
    [Fact]
    public void Resolution_CanResolveInterfaces()
    {
        var repoDef = CreateSchemaService(typeof(IRepository), typeof(Repository));
        var serviceDef = CreateSchemaService(typeof(IService), typeof(Samples.Lib.Impl.Service));

        var serviceProvider = LoadServiceProvider(repoDef, serviceDef);

        var service = serviceProvider.GetRequiredService<IService>();

        Assert.NotNull(service);
    }

    private static IServiceProvider LoadServiceProvider(params Schema.Service[] services)
    {
        var servicesObj = new Services { Collection = services.ToArray() };

        return LoadServiceProvider(servicesObj);
    }

    private static IServiceProvider LoadServiceProvider(Services services)
    {
        var serviceCollection = new ServiceCollection();

        ServiceCollectionLoader.LoadServices(serviceCollection, services, DependencyInjectionConfigurationOptions.Default);

        return serviceCollection.BuildServiceProvider();
    }

    private static Schema.Service CreateSchemaService(Type serviceType, Type implType)
    {
        return new Schema.Service { ServiceType = serviceType.AssemblyQualifiedName, ImplementationType = implType.AssemblyQualifiedName };
    }
}