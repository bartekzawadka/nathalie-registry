using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Dto.Filters;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.Api.Controllers
{
    public class TemplatesController : ControllerBase<Template, TemplatesFilter>
    {
        public TemplatesController(ITemplatesService templatesService)
            : base(templatesService)
        {
            
        }
    }
}