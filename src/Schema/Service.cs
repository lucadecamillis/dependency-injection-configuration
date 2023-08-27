using Microsoft.Extensions.DependencyInjection;

namespace LdC.DependencyInjection.Configuration.Schema
{
    internal class Service
    {
        /// <summary>
        /// Type of service to be registered (Required)
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// Implementation of <see cref="ServiceType"/> (Optional)
        /// If not specified <see cref="ServiceType"/> is used as implementation
        /// </summary>
        public string ImplementationType { get; set; }

        /// <summary>
        /// Lifetime of the registration (<see href="https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime"/>)
        /// </summary>
        public ServiceLifetime? Lifetime { get; set; }

        /// <summary>
        /// Factory that can be used to build the <see cref="ServiceType"/>
        /// </summary>
        public Factory Factory { get; set; }
    }
}