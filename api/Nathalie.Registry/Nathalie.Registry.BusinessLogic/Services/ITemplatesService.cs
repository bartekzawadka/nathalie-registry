using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface ITemplatesService
    {
        Task<IEnumerable<Template>> GetList(Expression<Func<Template, bool>> filter = null);

        Task<Template> GetItem(string id);

        Task Add(Template template);
        
        Task Update(string id, Template template);

        Task<bool> Delete(string id);

        IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes();
    }
}