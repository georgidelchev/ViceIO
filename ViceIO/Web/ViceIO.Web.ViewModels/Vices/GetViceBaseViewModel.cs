using System;

namespace ViceIO.Web.ViewModels.Vices
{
    public class GetViceBaseViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString
            => this.CreatedOn.ToShortDateString();
    }
}
