using Nathalie.Registry.DataLayer.Enums;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("templateFields")]
    public class TemplateField : DocumentBase
    {
        public string Name { get; set; }

        public TemplateFieldType FieldType { get; set; }

        public bool IsCalculated { get; set; }

        public bool IsSum { get; set; }

        public string Formula { get; set; }
        
        public object Value { get; set; }
    }
}