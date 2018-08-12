﻿namespace Nathalie.Registry.DataLayer.Models
{
    public class RegistryEntityRow
    {
        public string TemplateName { get; set; }

        public int RowNumber { get; set; }

        public TemplateField Field { get; set; }

        public object Value { get; set; }
    }
}