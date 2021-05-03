using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViceIO.Web.ViewModels.Riddles
{
   public class CreateRiddleInputModel
    {
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
    }
}
