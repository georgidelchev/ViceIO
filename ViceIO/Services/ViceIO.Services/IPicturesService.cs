using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public interface IPicturesService
    {
        Task CreateAsync(CreatePictureInputModel input, string userId);

        IEnumerable<GetPictureBaseViewModel> GetAll();

        GetPictureBaseViewModel GetRandom();

        int GetCount();

        GetPictureBaseViewModel GetById(int pictureId);
    }
}
