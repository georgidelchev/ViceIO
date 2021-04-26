using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViceIO.Web.ViewModels.VicesCategories;

namespace ViceIO.Web.ViewModels.Vices
{
    public class CreateViceInputModel
    {
        public string Content { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<VicesCategoriesModel> Categories { get; set; }
    }
}
