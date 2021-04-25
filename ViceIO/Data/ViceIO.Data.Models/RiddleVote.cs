using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class RiddleVote : BaseModel<int>
    {
        [Required]
        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public byte Value { get; set; }
    }
}
