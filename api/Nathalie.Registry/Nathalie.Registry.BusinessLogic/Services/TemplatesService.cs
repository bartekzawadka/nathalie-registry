using System.Collections.Generic;
using System.Linq;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class TemplatesService : ITemplatesService
    {
        public IEnumerable<Template> GetTemplates()
        {
            using (var work = new UnitOfWork())
            {
                return work.GetRepository<Template>().Get().ToList();
            }
        }
    }
}