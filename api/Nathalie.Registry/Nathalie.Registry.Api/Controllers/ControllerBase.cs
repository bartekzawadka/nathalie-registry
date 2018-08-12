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
        private readonly IService<T> _service;

        protected ControllerBase(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _service.GetList();
        }

        [HttpGet("{id}")]
        public virtual async Task<T> Get(string id)
        {
            return await _service.GetItem(id);
        }

        [HttpPost]
        public virtual async Task Post([FromBody] T item)
        {
            await _service.Add(item);
        }

        [HttpPut("{id}")]
        public virtual async void Put(string id, [FromBody] T item)
        {
            await _service.Update(id, item);
        }

        [HttpDelete("{id}")]
        public virtual async void Delete(string id)
        {
            await _service.Delete(id);
        }
    }
}
