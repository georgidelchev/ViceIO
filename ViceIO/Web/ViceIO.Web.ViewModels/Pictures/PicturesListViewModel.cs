using System.Collections.Generic;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class PicturesListViewModel
    {
        public IEnumerable<GetPictureBaseViewModel> Pictures { get; set; }
    }
}
