using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class RegistriesService :
        Service<DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>>,
        IRegistriesService
    {
        public Task<RegistryEntity> GetEntity(string registryId, string templateName)
        {
            return ExecuteUnitOfWorkAsync(async work =>
            {
                var repo = work.GetRepository<DataLayer.Models.Registry>();
                var registry = await repo.GetById(registryId);
                var entity = registry.RegistryEntities.FirstOrDefault(re =>
                    string.Equals(re.Template.Name.ToLower(), templateName.ToLower()));

                if (entity == null)
                {
                    return null;
                }

                if (entity.DataIds != null && entity.DataIds.Any())
                {
                    entity.Data = await work.ResolveReferences<RegistryEntityRow>(entity.DataIds);
                }

                entity.RegistryDate = registry.RegistryDate;

                return entity;
            });
        }

        public async Task UpsertEntity(string registryId, RegistryEntity entity)
        {
            await ExecuteUnitOfWorkAsync(async work =>
            {
                var registryRepo = work.GetRepository<DataLayer.Models.Registry>();
                var registryEntityRowRepo = work.GetRepository<RegistryEntityRow>();
                
                var registry = await registryRepo.GetById(registryId);

                var registryRecords = registry.RegistryEntities.First(f => f.Template.Name == entity.Template.Name);
                
                if (registryRecords.DataIds != null)
                {
                    await registryEntityRowRepo
                        .DeleteMany(registryRecords.DataIds);
                }

                var data = entity.Data.Where(item => !item.IsEmpty()).ToList();
                var registryElement = registry.RegistryEntities.First(f => f.Template.Name == entity.Template.Name);
                
                if (data.Count > 0)
                {
                    await registryEntityRowRepo.InsertMany(data);
                    
                    var list = data.Select(x => x.Id).ToList();

                    registryElement.DataIds = list;
                }
                else
                {
                    registryElement.DataIds = new List<string>();
                }

                registryElement.IsFilledIn = data.Count > 0;

                await registryRepo.Update(registry.Id, registry);
            });
        }
    }
}