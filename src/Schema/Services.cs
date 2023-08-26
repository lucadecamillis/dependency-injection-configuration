using System;
using System.Collections.Generic;

namespace LdC.DependencyInjection.Configuration.Schema
{
    internal class Services
    {
        public IEnumerable<Service> Collection { get; set; }

        public Services()
        {
            this.Collection = Array.Empty<Service>();
        }
    }
}