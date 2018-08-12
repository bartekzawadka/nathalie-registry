using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegistriesController : Controller
    {
        private readonly IRegistriesService _registriesService;

        public RegistriesController(IRegistriesService registriesService)
        {
            _registriesService = registriesService;
        }

        [HttpGet]
        public async Task<IEnumerable<DataLayer.Models.Registry>> Get()
        {
            return await _registriesService.GetList();
        }

        [HttpGet("{id}")]
        public async Task<DataLayer.Models.Registry> Get(string id)
        {
            return await _registriesService.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Registry.DataLayer.Models.Registry template)
        {
            await _registriesService.Add(template);
        }

        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Registry.DataLayer.Models.Registry template)
        {
            await _registriesService.Update(id, template);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _registriesService.Delete(id);
        }
    }
}