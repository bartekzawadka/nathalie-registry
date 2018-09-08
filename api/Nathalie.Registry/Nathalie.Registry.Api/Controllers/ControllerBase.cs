using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nathalie.Registry.BusinessLogic.Services;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ControllerBase<T> : Controller where T : DocumentBase
    {
        protected readonly IService<T> Service;

        protected ControllerBase(IService<T> service)
        {
            Service = service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await Service.GetList();
        }

        [HttpGet("{id}")]
        public virtual async Task<T> Get(string id)
        {
            return await Service.GetItem(id);
        }

        [HttpPost]
        public virtual async Task Post([FromBody] T item)
        {
            await Service.Add(item);
        }

        [HttpPut("{id}")]
        public virtual async void Put(string id, [FromBody] T item)
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
