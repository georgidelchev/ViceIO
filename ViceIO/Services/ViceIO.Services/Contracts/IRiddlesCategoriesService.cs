using System.Collections.Generic;

using ViceIO.Web.ViewModels.RiddlesCategories;

namespace ViceIO.Services
{
    public interface IRiddlesCategoriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
