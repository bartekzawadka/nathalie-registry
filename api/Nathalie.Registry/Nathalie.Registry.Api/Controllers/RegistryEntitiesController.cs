using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegistryEntitiesController : ControllerBase<RegistryEntity>
    {
        public RegistryEntitiesController(IService<RegistryEntity> registryEntitiesService)
            : base(registryEntitiesService)
        {
        }
    }
}
