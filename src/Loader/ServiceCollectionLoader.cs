using System;
using LdC.DependencyInjection.Configuration.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace LdC.DependencyInjection.Configuration.Loader
{
    /// <summary>
    /// Service collection loader
    /// </summary>
    internal static class ServiceCollectionLoader
    {
        /// <summary>
        /// Load the service collection from the services definition
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="services"></param>
        /// <param name="options"></param>
        public static void LoadServices(
            IServiceCollection serviceCollection,
            Services services,
            DependencyInjectionConfigurationOptions options)
        {
            foreach (var service in services.Collection)
            {
                LoadService(serviceCollection, service);
            }
        }

        private static void LoadService(IServiceCollection serviceCollection, Service service)
        {
            Type serviceType = TryParseType(service.ServiceType);
            Type implType = TryParseType(service.ImplementationType);

            var descriptor = new ServiceDescriptor(
                serviceType,
                implType,
                service.Lifetime.GetValueOrDefault(ServiceLifetime.Transient));

            serviceCollection.Add(descriptor);
        }

        private static Type TryParseType(string typeString)
        {
            if (string.IsNullOrWhiteSpace(typeString))
            {
                return null;
            }

            return Type.GetType(typeString, throwOnError: true, ignoreCase: true);
        }
    }
}