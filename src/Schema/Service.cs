using Microsoft.Extensions.DependencyInjection;

namespace LdC.DependencyInjection.Configuration.Schema
{
    internal class Service
    {
        public string Name { get; set; }

        public string ServiceType { get; set; }

        public string ImplementationType { get; set; }

        public ServiceLifetime? Lifetime { get; set; }
    }
}