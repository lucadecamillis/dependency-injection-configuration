namespace LdC.DependencyInjection.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyInjectionConfigurationOptions
    {
        /// <summary>
        /// Default options value
        /// </summary>
        public static DependencyInjectionConfigurationOptions Default { get; } = new DependencyInjectionConfigurationOptions();

        /// <summary>
        /// Path to the JSON section where services definition is located
        /// </summary>
        public string Path { get; set; }

        public DependencyInjectionConfigurationOptions()
        {
            this.Path = "Services";
        }
    }
}