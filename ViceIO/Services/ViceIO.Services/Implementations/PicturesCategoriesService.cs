using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Contracts;
using ViceIO.Services.Mapping;

namespace ViceIO.Services.Implementations
{
    public class PicturesCategoriesService : IPicturesCategoriesService
    {
        private readonly IDeletableEntityRepository<PictureCategory> picturesCategoryRepository;

        public PicturesCategoriesService(
            IDeletableEntityRepository<PictureCategory> picturesCategoryRepository)
        {
            this.picturesCategoryRepository = picturesCategoryRepository;
        }

        public IEnumerable<T> GetAll<T>()
            => this.picturesCategoryRepository
                .All()
                .To<T>()
                .ToList();
    }
}
