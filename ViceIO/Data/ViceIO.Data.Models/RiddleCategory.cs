using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class RiddleCategory : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
