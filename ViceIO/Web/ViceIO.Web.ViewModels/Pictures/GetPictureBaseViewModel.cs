using System;
using System.Collections.Generic;
using System.Text;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class GetPictureBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string SourceUrl { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString
            => this.CreatedOn.ToShortDateString();

        public string AddedByUserId { get; set; }
    }
}
