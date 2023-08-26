using LdC.DependencyInjection.Configuration.Sample.Interfaces;

namespace LdC.DependencyInjection.Configuration.Sample.Impl;

public class Service : IService
{
    readonly IRepository repo;

    public Service(IRepository repo)
    {
        this.repo = repo;
    }
}