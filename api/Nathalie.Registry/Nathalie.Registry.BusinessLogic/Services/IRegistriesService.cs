using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface IRegistriesService : IService<DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>>
    {
        Task<RegistryEntity> GetEntity(string registryId, string templateName);
    }
}