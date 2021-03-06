using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViceIO.Web.ViewModels.Feedback
{
    public class CreateFeedbackInputModel
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Content { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
