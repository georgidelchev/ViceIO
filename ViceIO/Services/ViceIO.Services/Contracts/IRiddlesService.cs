using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Riddles;

namespace ViceIO.Services
{
    public interface IRiddlesService
    {
        Task CreateAsync(CreateRiddleInputModel input, string userId);

        IEnumerable<T> GetAll<T>();

        T GetRandom<T>();

        int GetCount();

        T GetById<T>(int pictureId);
    }
}
