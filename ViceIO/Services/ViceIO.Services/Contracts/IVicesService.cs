using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Services
{
    public interface IVicesService
    {
        Task CreateAsync(CreateViceInputModel input, string userId);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        T GetRandom<T>();

        int GetCount();

        T GetById<T>(int viceId);
    }
}
