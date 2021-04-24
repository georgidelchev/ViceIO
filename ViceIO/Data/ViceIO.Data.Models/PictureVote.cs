using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class PictureVote : BaseModel<int>
    {
        [Required]
        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public byte Value { get; set; }
    }
}
