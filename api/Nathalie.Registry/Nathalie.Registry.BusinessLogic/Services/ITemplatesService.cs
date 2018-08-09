using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface ITemplatesService
    {
        Task<IEnumerable<Template>> GetTemplates(Expression<Func<Template, bool>> filter = null);

        Task<Template> GetTemplate(string id);

        Task AddTemplate(Template template);
        
        Task UpdateTemplate(string id, Template template);

        Task<bool> DeleteTemplate(string id);

        IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes();
    }
}