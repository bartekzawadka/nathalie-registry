using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.DataLayer.Models
{
    public class TemplateColumn : IIdentifiable
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public CalculationType CalculationType { get; set; }
        
        public long TemplateColumnTypeId { get; set; }
        
        public TemplateColumnType TemplateColumnType { get; set; }
    }
}