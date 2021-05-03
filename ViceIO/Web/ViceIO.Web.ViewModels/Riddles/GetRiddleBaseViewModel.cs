using System;
using System.Collections.Generic;
using System.Text;

namespace ViceIO.Web.ViewModels.Riddles
{
   public class GetRiddleBaseViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Answer { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString
            => this.CreatedOn.ToShortDateString();

        public string AddedByUserId { get; set; }
    }
}
