namespace Nathalie.Registry.DataLayer.Models
{
    public class RegistryRow : DocumentBase
    {
        public string TemplateName { get; set; }

        public int RowNumber { get; set; }

        public string ColumnName { get; set; }

        public object Value { get; set; }
    }
}