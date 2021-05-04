using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public string LocalUrl { get; set; }

        public string SourceUrl { get; set; }

        public string Extension { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public PictureCategory Category { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public ICollection<PictureVote> PictureVotes { get; set; }
            = new HashSet<PictureVote>();
    }
}
