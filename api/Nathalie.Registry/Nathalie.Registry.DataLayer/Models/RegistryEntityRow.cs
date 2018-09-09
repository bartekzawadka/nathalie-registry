using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("registryData")]
    public class RegistryEntityRow : DocumentBase
    {
        public int RowNumber { get; set; }

        public Dictionary<TemplateField, object> ColumnValues { get; set; }
    }
}