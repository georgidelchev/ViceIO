using System.Collections.Generic;

namespace ViceIO.Web.ViewModels.Vices
{
    public class AllVicesListViewModel : PagingViewModel
    {
        public IEnumerable<GetAllVicesViewModel> Vices { get; set; }
    }
}
