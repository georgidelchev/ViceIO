using System.Collections.Generic;

using ViceIO.Web.ViewModels.VicesCategories;

namespace ViceIO.Services
{
    public interface IVicesCategoriesService
    {
        IEnumerable<VicesCategoriesModel> GetAll();
    }
}
