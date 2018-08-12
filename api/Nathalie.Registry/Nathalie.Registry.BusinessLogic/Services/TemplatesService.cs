using System;
using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Enums;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class TemplatesService : Service<Template>, ITemplatesService
    {
        public IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes()
        {
            foreach (object value in Enum.GetValues(typeof(TemplateFieldType)))
            {
                yield return new KeyValuePair<string, int>(value.ToString(), (int) value);
            }
        }
    }
}