using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.BusinessLogic.Dto.Filters
{
    public class TemplatesFilter : Filter<Template>
    {
        public bool ActiveOnly { get; set; } = true;
    }
}