using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.VicesCategories
{
    public class VicesCategoriesModel : IMapFrom<ViceCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
