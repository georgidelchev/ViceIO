using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class ViceCategory : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
