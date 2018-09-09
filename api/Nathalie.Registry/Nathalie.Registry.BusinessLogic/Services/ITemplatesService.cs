using System.Collections.Generic;
using Nathalie.Registry.BusinessLogic.Dto.Filters;
using Nathalie.Registry.BusinessLogic.Dto.Templates;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface ITemplatesService : IService<Template, TemplatesFilter>
    {
        IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes();

        bool IsFormulaValid(FormulaValidationQuery formulaValidationQuery);
    }
}