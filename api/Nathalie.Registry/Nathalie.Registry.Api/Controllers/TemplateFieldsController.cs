using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public class TemplateFieldsController : Controller
    {
        private readonly ITemplatesService _templatesService;

        public TemplateFieldsController(ITemplatesService templatesService)
        {
            _templatesService = templatesService;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetTemplateFieldTypes()
        {
            return Json(_templatesService.GetTemplateFieldTypes());
        }
    }
}