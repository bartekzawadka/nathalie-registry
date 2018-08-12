using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.Api.Controllers
{
    public class TemplatesController : ControllerBase<Template>
    {
        public TemplatesController(ITemplatesService templatesService)
            : base(templatesService)
        {
        }
    }
}