using System;
using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.DataLayer.Models
{
    public class Registry : IIdentifiable
    {
        public long Id { get; set; }

        public DateTime RegistryDate { get; set; }
        
        public ICollection<RegistryTemplate> RegistryTemplates { get; set; }
    }
}