using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface IService<TModel> where TModel : DocumentBase
    {
        Task<IEnumerable<TModel>> GetList(Expression<Func<TModel, bool>> filter = null);

        Task<TModel> GetItem(string id);

        Task Add(TModel document);

        Task AddMany(IEnumerable<TModel> documents);

        Task Update(string id, TModel document);

        Task<bool> Delete(string id);
    }
}
