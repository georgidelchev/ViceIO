using System;

using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Vices
{
    public class GetViceBaseViewModel : IMapFrom<Vice>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString
            => this.CreatedOn.ToShortDateString();

        public string AddedByUserId { get; set; }
    }
}
