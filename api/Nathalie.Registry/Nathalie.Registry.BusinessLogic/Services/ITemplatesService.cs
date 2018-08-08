using System.Collections.Generic;
using System.Threading.Tasks;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface ITemplatesService
    {
        Task<IEnumerable<Template>> GetTemplates();
    }
}