using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.RiddlesCategories
{
    public class RiddlesCategoriesModel : IMapFrom<RiddleCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
