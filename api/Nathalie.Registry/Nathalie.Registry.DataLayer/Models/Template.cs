using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("templates")]
    public class Template : DocumentBase
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        [Required(ErrorMessage = "Template fields have to be specified")]
        public IEnumerable<TemplateField> TemplateFields { get; set; }
    }
}