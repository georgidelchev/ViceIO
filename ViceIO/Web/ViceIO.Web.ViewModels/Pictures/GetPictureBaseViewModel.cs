using System;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class GetPictureBaseViewModel:IMapFrom<Picture>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SourceUrl { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserEmail { get; set; }

        public string Extension { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString
            => this.CreatedOn.ToShortDateString();

        public string AddedByUserId { get; set; }
    }
}
