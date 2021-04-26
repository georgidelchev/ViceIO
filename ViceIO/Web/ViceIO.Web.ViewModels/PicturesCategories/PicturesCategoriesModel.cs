using System.ComponentModel.DataAnnotations;

namespace ViceIO.Web.ViewModels.PicturesCategories
{
    public class PicturesCategoriesModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
