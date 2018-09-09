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
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Get(filter));
        }

        public virtual Task<TModel> GetItem(string id)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().GetById(id));
        }

        public virtual Task Add(TModel document)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Insert(document));
        }

        public virtual Task AddMany(IEnumerable<TModel> documents)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().InsertMany(documents));
        }
        
        public virtual Task Update(string id, TModel document)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Update(id, document));
        }

        public virtual Task<bool> Delete(string id)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Delete(id));
        }

        protected TOut ExecuteUnitOfWork<TOut>(Func<UnitOfWork, TOut> func)
        {
            using (var work = new UnitOfWork())
            {
                return func(work);
            }
        }
    }
}