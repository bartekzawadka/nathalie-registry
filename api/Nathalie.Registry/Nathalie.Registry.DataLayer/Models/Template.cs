using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.DataLayer.Models
{
    public class Template : IIdentifiable
    {
        public Template()
        {
            TemplateColumns = new HashSet<TemplateColumn>();
            RegistryTemplates = new HashSet<RegistryTemplate>();
        }
        
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<TemplateColumn> TemplateColumns { get; set; }
        
        public ICollection<RegistryTemplate> RegistryTemplates { get; set; }
    }
}