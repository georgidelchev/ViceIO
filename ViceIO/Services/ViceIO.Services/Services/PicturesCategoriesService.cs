using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.PicturesCategories;

namespace ViceIO.Services.Services
{
    public class PicturesCategoriesService : IPicturesCategoriesService
    {
        private readonly IDeletableEntityRepository<PictureCategory> picturesCategoryRepository;

        public PicturesCategoriesService(
            IDeletableEntityRepository<PictureCategory> picturesCategoryRepository)
        {
            this.picturesCategoryRepository = picturesCategoryRepository;
        }

        public IEnumerable<PicturesCategoriesModel> GetAll()
        {
            var picturesCategories = this.picturesCategoryRepository
                .All()
                .Select(x => new PicturesCategoriesModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return picturesCategories;
        }
    }
}
