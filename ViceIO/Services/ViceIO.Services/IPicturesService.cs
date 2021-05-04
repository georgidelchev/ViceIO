using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public interface IPicturesService
    {
        Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath);

        IEnumerable<GetPictureBaseViewModel> GetAll(int page, int itemsPerPage = 12);

        GetPictureBaseViewModel GetRandom();

        int GetCount();

        GetPictureBaseViewModel GetById(int pictureId);
    }
}
