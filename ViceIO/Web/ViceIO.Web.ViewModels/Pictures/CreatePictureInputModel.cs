using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using ViceIO.Web.ViewModels.PicturesCategories;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class CreatePictureInputModel
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "Picture Name")]
        public string Name { get; set; }

        public string SourceUrl { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<PicturesCategoriesModel> Categories { get; set; }

        public IFormFile Picture { get; set; }
    }
}
