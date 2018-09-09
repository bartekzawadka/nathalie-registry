using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.Api.Controllers
{
    public class RegistriesController : ControllerBase<DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>>
    {
        public RegistriesController(
            IService<DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>> registriesService)
            : base(registriesService)
        {
        }
    }
}