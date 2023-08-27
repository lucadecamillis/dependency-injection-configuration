using Microsoft.Extensions.DependencyInjection;
using Samples.Lib.Factories;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;

namespace LdC.DependencyInjection.Configuration.Tests;

public class FactoryTests
{
    [Fact]
    public void Factory_CanResolve()
    {
        var factoryDef = TestUtilities.CreateSchemaFactory(typeof(IComplexService), typeof(ComplexServiceFactory), "Create");
        var contextDef = TestUtilities.CreateSchemaService(typeof(Context));

        var serviceProvider = TestUtilities.LoadServiceProvider(factoryDef, contextDef);

        var service = serviceProvider.GetRequiredService<IComplexService>();

        Assert.NotNull(service);
    }
}