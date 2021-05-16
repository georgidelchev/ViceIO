using System.Collections.Generic;
using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public interface IPicturesService
    {
        Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        T GetRandom<T>();

        int GetCount();

        T GetById<T>(int pictureId);

        T Details<T>(int pictureId);

        IEnumerable<T> Get12TopRated<T>();
    }
}
