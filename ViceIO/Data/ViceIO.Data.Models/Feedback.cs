using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class Feedback : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Content { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsClosed { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
