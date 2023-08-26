using LdC.DependencyInjection.Configuration.Schema;
using Microsoft.Extensions.Configuration;

namespace LdC.DependencyInjection.Configuration.Parsing
{
    /// <summary>
    /// JSON schema parser
    /// </summary>
    internal static class SchemaParser
    {
        /// <summary>
        /// Parse the JSON schema into a valid services definition object
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Services TryParseService(
            IConfiguration configuration,
            DependencyInjectionConfigurationOptions options)
        {
            var services = configuration.GetSection(options.Path).Get<Services>();

            return services;
        }
    }
}