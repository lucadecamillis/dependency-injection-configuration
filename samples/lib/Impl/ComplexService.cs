using Samples.Lib.Interfaces;

namespace Samples.Lib.Impl;

internal class ComplexService : IComplexService
{
    readonly Context context;

    public ComplexService(Context context)
    {
        this.context = context;
    }
}