using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViceIO.Web.ViewModels.Feedback
{
    public class CreateFeedbackInputModel
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

        [Required]
        public string UserId { get; set; }
    }
}
