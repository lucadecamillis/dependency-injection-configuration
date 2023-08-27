using Samples.Lib.Interfaces;

namespace Samples.Lib.Impl;

public class Service : IService
{
    readonly IRepository repo;

    public Service(IRepository repo)
    {
        this.repo = repo;
    }
}