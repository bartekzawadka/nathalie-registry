using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class Service<TModel, TFilter> : IService<TModel, TFilter>
        where TModel : DocumentBase
        where TFilter : Filter<TModel>, new()
    {
        public virtual Task<IEnumerable<TModel>> GetList(TFilter filter)
        {
            return ExecuteUnitOfWorkAsync(work => work.GetRepository<TModel>().Get(filter));
        }

        public virtual Task<TModel> GetItem(string id)
        {
            return ExecuteUnitOfWorkAsync(work => work.GetRepository<TModel>().GetById(id));
        }

        public virtual async Task Add(TModel document)
        {
            await ExecuteUnitOfWorkAsync(async work => await work.GetRepository<TModel>().Insert(document));
        }

        public virtual async Task AddMany(IEnumerable<TModel> documents)
        {
            await ExecuteUnitOfWorkAsync(async work => await work.GetRepository<TModel>().InsertMany(documents));
        }
        
        public virtual async Task Update(string id, TModel document)
        {
            await ExecuteUnitOfWorkAsync(async work => await work.GetRepository<TModel>().Update(id, document));
        }

        public virtual Task<bool> Delete(string id)
        {
            return ExecuteUnitOfWorkAsync(work => work.GetRepository<TModel>().Delete(id));
        }

        protected async Task ExecuteUnitOfWorkAsync(Func<UnitOfWork, Task> func)
        {
            using (var work = new UnitOfWork())
            {
                await func(work);
            }
        }
        
        protected async Task<TOut> ExecuteUnitOfWorkAsync<TOut>(Func<UnitOfWork, Task<TOut>> func)
        {
            using (var work = new UnitOfWork())
            {
                return await func(work);
            }
        }
    }
}