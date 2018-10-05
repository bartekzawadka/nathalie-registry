using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ControllerBase<TService, TModel, TFilter> : Controller
        where TModel : DocumentBase
        where TFilter : Filter<TModel>
        where TService : IService<TModel, TFilter>
    {
        protected readonly TService Service;

        protected ControllerBase(TService service)
        {
            Service = service;
        }
        
        [HttpGet]
        public virtual async Task<IEnumerable<TModel>> Get([FromQuery] TFilter filter)
        {
            return await Service.GetList();
        }

        [Route("list")]
        [HttpPost]
        public virtual async Task<IEnumerable<TModel>> GetList([FromBody] TFilter filter)
        {
            return await Service.GetList(filter);
        }

        [HttpGet("{id}")]
        public virtual async Task<TModel> Get(string id)
        {
            return await Service.GetItem(id);
        }

        [HttpPost]
        public virtual async Task Post([FromBody] TModel item)
        {
            await Service.Add(item);
        }

        [HttpPut("{id}")]
        public virtual async void Put(string id, [FromBody] TModel item)
        {
            await Service.Update(id, item);
        }

        [HttpDelete("{id}")]
        public virtual async void Delete(string id)
        {
            await Service.Delete(id);
        }
    }
}
