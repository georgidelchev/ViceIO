using System.Collections.Generic;

using ViceIO.Web.ViewModels.PicturesCategories;

namespace ViceIO.Services
{
    public interface IPicturesCategoriesService
    {
        IEnumerable<PicturesCategoriesModel> GetAll();
    }
}
