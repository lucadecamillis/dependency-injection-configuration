using Samples.Lib.Impl;
using Samples.Lib.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Lib.Factories;

public static class ComplexServiceFactory
{
    public static IComplexService Create(IServiceProvider provider)
    {
        var context = provider.GetRequiredService<Context>();

        return new ComplexService(context);
    }
}