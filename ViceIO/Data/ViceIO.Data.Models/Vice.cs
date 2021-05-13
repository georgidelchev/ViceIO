using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class Vice : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ViceCategory Category { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public ICollection<ViceVote> ViceVotes { get; set; }
            = new HashSet<ViceVote>();
    }
}
