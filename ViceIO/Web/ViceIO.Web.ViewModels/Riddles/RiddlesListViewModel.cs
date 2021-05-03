using System.Collections.Generic;

namespace ViceIO.Web.ViewModels.Riddles
{
    public class RiddlesListViewModel
    {
        public IEnumerable<GetRiddleBaseViewModel> Riddles { get; set; }
    }
}
