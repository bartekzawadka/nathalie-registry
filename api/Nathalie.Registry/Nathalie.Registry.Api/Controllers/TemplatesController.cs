using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        private readonly ITemplatesService _templatesService;

        public TemplatesController(ITemplatesService templatesService)
        {
            _templatesService = templatesService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Template>> Get()
        {
            return await _templatesService.GetList();
        }
        
        [HttpGet("{id}")]
        public async Task<Template> Get(string id)
        {
            return await _templatesService.GetItem(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] Template template)
        {
            await _templatesService.Add(template);
        }
        
        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Template template)
        {
            await _templatesService.Update(id, template);
        }
        
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _templatesService.Delete(id);
        }
    }
}