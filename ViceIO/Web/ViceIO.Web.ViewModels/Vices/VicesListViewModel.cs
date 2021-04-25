using System.Collections.Generic;

namespace ViceIO.Web.ViewModels.Vices
{
    public class VicesListViewModel
    {
        public IEnumerable<GetAllVicesViewModel> Vices { get; set; }
    }
}
