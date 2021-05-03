using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.RiddlesCategories;

namespace ViceIO.Services
{
    public class RiddlesCategoriesService : IRiddlesCategoriesService
    {
        private readonly IDeletableEntityRepository<RiddleCategory> riddlesCategoriesRepository;

        public RiddlesCategoriesService(IDeletableEntityRepository<RiddleCategory> riddlesCategoriesRepository)
        {
            this.riddlesCategoriesRepository = riddlesCategoriesRepository;
        }

        public IEnumerable<RiddlesCategoriesModel> GetAll()
        {
            var riddlesCategories = this.riddlesCategoriesRepository
                .All()
                .Select(rc => new RiddlesCategoriesModel()
                {
                    Id = rc.Id,
                    Name = rc.Name,
                })
                .ToList();

            return riddlesCategories;
        }
    }
}
