using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class RegistriesService : 
        Service<DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>>,
        IRegistriesService
    {
        public Task<RegistryEntity> GetEntity(string registryId, string templateName)
        {
            return ExecuteUnitOfWork(async work =>
            {
                var repo = await work.GetRepository<DataLayer.Models.Registry>().GetById(registryId);
                var entity = repo.RegistryEntities.FirstOrDefault(re =>
                    string.Equals(re.Template.Name.ToLower(), templateName.ToLower()));

                if (entity == null)
                {
                    return null;
                }
                
                if (entity.DataIds != null && entity.DataIds.Any())
                {
//                    var records = new List<RegistryEntityRow>();
//
//                    Parallel.ForEach(entity.DataIds, async element =>
//                    {
//                        records.Add(await work.ResolveReference<RegistryEntityRow>(element));
//                    });

                    entity.Data = await 
                        work.ResolveReferences<RegistryEntityRow>(entity.DataIds.First().CollectionName,
                            entity.DataIds); // records;
                }
                
                return entity;
            });
        }
    }
}