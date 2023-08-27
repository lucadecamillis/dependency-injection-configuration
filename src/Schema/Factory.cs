namespace LdC.DependencyInjection.Configuration.Schema
{
    internal class Factory
    {
        /// <summary>
        /// Type where the factory method resides
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Factory method
        /// </summary>
        public string Method { get; set; }
    }
}