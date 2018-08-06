using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.DataLayer.Models
{
    public class RegistryTemplate : IIdentifiable
    {
        public long Id { get; set; }

        public long RegistryId { get; set; }
        
        public Registry Registry { get; set; }
        
        public long TemplateId { get; set; }

        public Template Template { get; set; }
    }
}