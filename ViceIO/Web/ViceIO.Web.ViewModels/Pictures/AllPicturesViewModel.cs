using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class AllPicturesViewModel : IMapFrom<Picture>
    {
        public int Id { get; set; }

        public string Extension { get; set; }
    }
}
