using Nathalie.Registry.BusinessLogic.Services;

namespace Nathalie.Registry.Api.Controllers
{
    public class RegistriesController : ControllerBase<DataLayer.Models.Registry>
    {
        public RegistriesController(IService<DataLayer.Models.Registry> registriesService)
            : base(registriesService)
        {
        }
    }
}