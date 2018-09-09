using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface IService<TModel, TFilter> where TModel : DocumentBase where TFilter : Filter<TModel>
    {
        Task<IEnumerable<TModel>> GetList(TFilter filter = null);

        Task<TModel> GetItem(string id);

        Task Add(TModel document);

        Task AddMany(IEnumerable<TModel> documents);

        Task Update(string id, TModel document);

        Task<bool> Delete(string id);
    }
}
