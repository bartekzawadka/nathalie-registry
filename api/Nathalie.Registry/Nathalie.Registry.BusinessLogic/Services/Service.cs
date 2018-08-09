using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public class Service<TModel> where TModel : DocumentBase
    {
        public virtual Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> filter = null)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Get());
        }

        public virtual Task<TModel> GetItem(string id)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().GetById(id));
        }

        public virtual Task Add(TModel document)
        {
            return ExecuteUnitOfWork(work => work.GetRepository<TModel>().Insert(document));
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