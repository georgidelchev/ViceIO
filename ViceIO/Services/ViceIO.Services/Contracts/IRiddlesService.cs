using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Riddles;

namespace ViceIO.Services
{
    public interface IRiddlesService
    {
        Task CreateAsync(CreateRiddleInputModel input, string userId);

        IEnumerable<GetAllRiddlesViewModel> GetAll();

        GetRiddleBaseViewModel GetRandom();

        int GetCount();

        GetRiddleBaseViewModel GetById(int pictureId);
    }
}
