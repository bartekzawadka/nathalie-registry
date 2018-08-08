using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("templates")]
    public class Template : DocumentBase
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public IEnumerable<TemplateField> TemplateFields { get; set; }
    }
}