using System.Collections.Generic;
using System.Linq;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer.Models
{
    [MongoCollection("registryData")]
    public class RegistryEntityRow : DocumentBase
    {
        public int RowNumber { get; set; }

        public List<RegistryEntityRowField> ColumnValues { get; set; }

        public bool IsEmpty()
        {
            return ColumnValues?.Where(item => item.Value != null).Any() != true;
        }
    }
}