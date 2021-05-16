using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.PicturesCategories
{
    public class PicturesCategoriesModel : IMapFrom<PictureCategory>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
