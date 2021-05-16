using System.Collections.Generic;

namespace ViceIO.Services.Contracts
{
    public interface IPicturesCategoriesService
    {
        IEnumerable<Т> GetAll<Т>();
    }
}
