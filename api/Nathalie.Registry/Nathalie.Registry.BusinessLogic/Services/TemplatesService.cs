using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nathalie.Registry.BusinessLogic.Dto.Templates;
using Nathalie.Registry.DataLayer.Enums;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class TemplatesService : Service<Template>, ITemplatesService
    {
        private const string ValidationFieldRegexPattern = @"\[(.*?)\]";
        private const string ValidationOperatorRegexPattern = @"[*+-/]";

        private static readonly Regex ValidationAllRegex =
            new Regex($"{ValidationFieldRegexPattern}|{ValidationOperatorRegexPattern}", RegexOptions.Compiled);

        private static readonly Regex ValidationFieldsRegex =
            new Regex(ValidationFieldRegexPattern, RegexOptions.Compiled);
        
        private static readonly Regex ValidationOperatorsRegex =
            new Regex(ValidationOperatorRegexPattern, RegexOptions.Compiled);
        
        public IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes()
        {
            foreach (object value in Enum.GetValues(typeof(TemplateFieldType)))
            {
                yield return new KeyValuePair<string, int>(value.ToString(), (int) value);
            }
        }

        public bool IsFormulaValid(FormulaValidationQuery formulaValidationQuery)
        {
            if (formulaValidationQuery == null ||
                formulaValidationQuery.IsCalculated && (string.IsNullOrEmpty(formulaValidationQuery.Formula) ||
                formulaValidationQuery.FieldNameCollection == null ||
                !formulaValidationQuery.FieldNameCollection.Any()))
            {
                return false;
            }
            if (!formulaValidationQuery.IsCalculated)
            {
                return true;
            }

            formulaValidationQuery.Formula = formulaValidationQuery.Formula.Trim();

            var matches = ValidationAllRegex.Matches(formulaValidationQuery.Formula);

            var fieldsCount = 0;
            var operatorsCount = 0;

            var previousWasField = false;
            var previousWasOperator = false;
            
            foreach (Match match in matches)
            {
                var fieldMatch = ValidationFieldsRegex.Match(match.Value);
                if (fieldMatch.Success)
                {
                    if (previousWasField)
                    {
                        return false;
                    }
                    if (!formulaValidationQuery.FieldNameCollection
                        .Any(field =>
                            (field.FieldType == TemplateFieldType.Money ||
                             field.FieldType == TemplateFieldType.Number) &&
                            string.Equals($"[{field.Name.ToLower()}]", fieldMatch.Value.ToLower())))
                    {
                        return false;
                    }

                    previousWasField = true;
                    previousWasOperator = false;
                    fieldsCount++;
                    continue;
                }

                if (ValidationOperatorsRegex.IsMatch(match.Value))
                {
                    if (previousWasOperator)
                    {
                        return false;
                    }

                    previousWasOperator = true;
                    previousWasField = false;
                    operatorsCount++;
                }
            }

            return operatorsCount == fieldsCount - 1;
        }
    }
}