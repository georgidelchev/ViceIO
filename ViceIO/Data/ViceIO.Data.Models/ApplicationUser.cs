using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using ViceIO.Data.Common.Models;

namespace ViceIO.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
            = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
            = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
            = new HashSet<IdentityUserLogin<string>>();

        public virtual ICollection<Vice> Vices { get; set; }
            = new HashSet<Vice>();

        public virtual ICollection<Picture> Picture { get; set; }
            = new HashSet<Picture>();

        public virtual ICollection<ViceVote> ViceVotes { get; set; }
            = new HashSet<ViceVote>();

        public virtual ICollection<PictureVote> PictureVotes { get; set; }
            = new HashSet<PictureVote>();

        public virtual ICollection<Feedback> Feedback { get; set; } = new HashSet<Feedback>();
    }
}
