using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Services
{
    public interface IVicesService
    {
        Task CreateAsync(CreateViceInputModel input);

        IEnumerable<GetAllVicesViewModel> GetAll();

        GetRandomViceViewModel GetRandom();

        int GetCount();

        GetViceBaseViewModel GetById(int viceId);
    }
}
