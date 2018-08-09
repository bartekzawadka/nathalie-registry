using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Enums;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class TemplatesService : ITemplatesService
    {
        public Task<IEnumerable<Template>> GetTemplates(Expression<Func<Template, bool>> filter = null)
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().Get();
            }
        }

        public Task<Template> GetTemplate(string id)
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().GetById(id);
            }
        }

        public Task AddTemplate(Template template)
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().Insert(template);
            }
        }

        public Task UpdateTemplate(string id, Template template)
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().Update(id, template);
            }
        }

        public Task<bool> DeleteTemplate(string id)
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().Delete(id);
            }
        }

        public IEnumerable<KeyValuePair<string, int>> GetTemplateFieldTypes()
        {
            foreach (var value in Enum.GetValues(typeof(TemplateFieldType)))
            {
                yield return new KeyValuePair<string, int>(value.ToString(), (int) value);
            }
        }
    }
}