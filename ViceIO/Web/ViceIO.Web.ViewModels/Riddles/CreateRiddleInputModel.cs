using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViceIO.Web.ViewModels.RiddlesCategories;

namespace ViceIO.Web.ViewModels.Riddles
{
   public class CreateRiddleInputModel
    {
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(50)]
        public string Answer { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<RiddlesCategoriesModel> Categories { get; set; }
    }
}
