using Microsoft.Extensions.DependencyInjection;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;

namespace LdC.DependencyInjection.Configuration.Tests;

public class ResolutionTests
{
    [Fact]
    public void Resolution_CanResolveInterfaces()
    {
        var repoDef = TestUtilities.CreateSchemaService(typeof(IRepository), typeof(Repository));
        var serviceDef = TestUtilities.CreateSchemaService(typeof(IService), typeof(Service));

        var serviceProvider = TestUtilities.LoadServiceProvider(repoDef, serviceDef);

        var service = serviceProvider.GetRequiredService<IService>();

        Assert.NotNull(service);
    }

    [Fact]
    public void Resolution_CanResolveGenerics()
    {
        var serviceDef = TestUtilities.CreateSchemaService(typeof(IGenericService<>), typeof(GenericService<>));

        var serviceProvider = TestUtilities.LoadServiceProvider(serviceDef);

        var service = serviceProvider.GetRequiredService<IGenericService<string>>();

        Assert.NotNull(service);
    }
}