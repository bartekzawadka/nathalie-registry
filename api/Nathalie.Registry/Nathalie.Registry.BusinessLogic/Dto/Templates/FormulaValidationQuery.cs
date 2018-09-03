using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Enums;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Dto.Templates
{
    public class FormulaValidationQuery
    {
        public string Formula { get; set; }

        public bool IsCalculated { get; set; }

        public IEnumerable<TemplateField> FieldNameCollection { get; set; }
    }
}