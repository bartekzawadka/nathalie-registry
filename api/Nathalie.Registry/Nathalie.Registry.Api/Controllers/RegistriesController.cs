using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.Api.Controllers
{
    public class RegistriesController :
        ControllerBase<IRegistriesService, DataLayer.Models.Registry, Filter<DataLayer.Models.Registry>>
    {
        public RegistriesController(IRegistriesService registriesService)
            : base(registriesService)
        {
        }

        [Route("{{id}}/entity/{{templateName}}")]
        [HttpGet]
        public async Task<RegistryEntity> GetEntity(string id, string templateName)
        {
            return await Service.GetEntity(id, templateName);
        }
    }
}