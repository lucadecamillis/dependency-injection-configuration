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
                serviceCollection.Add(LoadService(service));
            }
        }

        private static ServiceDescriptor LoadService(Service service)
        {
            var lifetime = service.Lifetime.GetValueOrDefault(ServiceLifetime.Transient);

            Type serviceType = TryParseType(service.ServiceType);
            if (serviceType == null)
            {
                throw new InvalidOperationException($"{nameof(Service.ServiceType)} is required");
            }

            if (service.Factory != null)
            {
                if (service.ImplementationType != null)
                {
                    throw new InvalidOperationException($"{nameof(Service.ImplementationType)} cannot be set when {nameof(Service.Factory)} is set");
                }

                return LoadServiceFromFactory(serviceType, service.Factory, lifetime);
            }
            else
            {
                return LoadServiceFromImplementation(serviceType, service.ImplementationType, lifetime);
            }
        }

        private static ServiceDescriptor LoadServiceFromFactory(Type serviceType, Factory factory, ServiceLifetime lifetime)
        {
            var factoryDelegate = ParseFactoryDelegate(serviceType, factory);

            var descriptor = new ServiceDescriptor(
                serviceType,
                factoryDelegate,
                lifetime);

            return descriptor;
        }

        private static ServiceDescriptor LoadServiceFromImplementation(Type serviceType, string implTypeString, ServiceLifetime lifetime)
        {
            // In case the implementation type is not provided use the service type
            Type implType = TryParseType(implTypeString) ?? serviceType;

            var descriptor = new ServiceDescriptor(
                serviceType,
                implType,
                lifetime);

            return descriptor;
        }

        private static Type TryParseType(string typeString)
        {
            if (string.IsNullOrWhiteSpace(typeString))
            {
                return null;
            }

            return Type.GetType(typeString, throwOnError: true, ignoreCase: true);
        }

        private static Func<IServiceProvider, object> ParseFactoryDelegate(Type serviceType, Factory factory)
        {
            if (string.IsNullOrWhiteSpace(factory.Method))
            {
                throw new InvalidOperationException($"Invalid factory for service {serviceType.Name}: no method name provided");
            }

            Type factoryType = TryParseType(factory.Type);
            if (factoryType == null)
            {
                throw new InvalidOperationException($"Invalid factory for service {serviceType.Name}: no type provided");
            }

            var method = factoryType.GetMethod(factory.Method);
            if (!method.IsStatic)
            {
                throw new InvalidOperationException($"Invalid factory for service {serviceType.Name}: method {factory.Method} from type {factoryType.Name} is not static");
            }
            
            var @delegate = method.CreateDelegate(typeof(Func<IServiceProvider, object>)) as Func<IServiceProvider, object>;

            return @delegate;
        }
    }
}