using System.Collections.Generic;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class PicturesListViewModel : PagingViewModel
    {
        public IEnumerable<AllPicturesViewModel> Pictures { get; set; }
    }
}
