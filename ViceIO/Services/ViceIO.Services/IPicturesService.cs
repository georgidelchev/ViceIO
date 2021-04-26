using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public interface IPicturesService
    {
        Task CreateAsync(CreatePictureInputModel input, string userId);
    }
}
