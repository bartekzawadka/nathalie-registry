using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface IRegistriesService
    {
        Task<IEnumerable<DataLayer.Models.Registry>> GetList(
            Expression<Func<DataLayer.Models.Registry, bool>> filter = null);

        Task<DataLayer.Models.Registry> GetItem(string id);

        Task Add(DataLayer.Models.Registry template);

        Task Update(string id, DataLayer.Models.Registry document);

        Task<bool> Delete(string id);
    }
}