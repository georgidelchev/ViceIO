using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class ViceVote : BaseModel<int>
    {
        [Required]
        public int ViceId { get; set; }

        public virtual Vice Vice { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public byte Value { get; set; }
    }
}
