using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class Riddle : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        [MaxLength(50)]
        public string Answer { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual RiddleCategory Category { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public ICollection<RiddleVote> RiddleVotes { get; set; }
            = new HashSet<RiddleVote>();
    }
}
