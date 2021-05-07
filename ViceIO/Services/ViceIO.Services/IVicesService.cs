using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Services
{
    public interface IVicesService
    {
        Task CreateAsync(CreateViceInputModel input, string userId);

        IEnumerable<GetAllVicesViewModel> GetAll(int page, int itemsPerPage = 12);

        GetRandomViceViewModel GetRandom();

        int GetCount();

        GetViceBaseViewModel GetById(int viceId);
    }
}
