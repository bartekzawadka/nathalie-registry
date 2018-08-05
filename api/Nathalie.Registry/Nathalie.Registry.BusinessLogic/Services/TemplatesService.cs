using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class TemplatesService : ITemplatesService
    {
        public void GetTemplates()
        {
            
        }

        public long Save()
        {
            using (var work = new UnitOfWork())
            {
                var template = new Template
                {
                    IsEnabled = true,
                    Name = "TEST"
                };
                
                work.GetRepository<Template>().Insert(template);
                work.Save();

                return template.Id;
            }
        }
    }
}