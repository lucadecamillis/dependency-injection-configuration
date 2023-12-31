using LdC.DependencyInjection.Configuration.Loader;
using LdC.DependencyInjection.Configuration.Parsing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LdC.DependencyInjection.Configuration
{
    public static class DependencyInjectionConfigurationExtensions
    {
        /// <summary>
        /// Load service collection from the configuration
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <param name="options"></param>
        public static void FromConfiguration(
            this IServiceCollection serviceCollection,
            IConfiguration configuration,
            DependencyInjectionConfigurationOptions options = null)
        {
            var opts = options ?? DependencyInjectionConfigurationOptions.Default;

            var services = SchemaParser.TryParseService(configuration, opts);
            if (services != null)
            {
                ServiceCollectionLoader.LoadServices(serviceCollection, services, opts);
            }
        }
    }
}