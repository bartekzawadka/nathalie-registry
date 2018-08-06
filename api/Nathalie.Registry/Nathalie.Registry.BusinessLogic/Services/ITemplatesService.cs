using System.Collections.Generic;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.BusinessLogic.Services
{
    public interface ITemplatesService
    {
        IEnumerable<Template> GetTemplates();
    }
}