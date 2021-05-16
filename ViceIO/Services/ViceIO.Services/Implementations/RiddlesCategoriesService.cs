using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Services.Services
{
    public class RiddlesCategoriesService : IRiddlesCategoriesService
    {
        private readonly IDeletableEntityRepository<RiddleCategory> riddlesCategoriesRepository;

        public RiddlesCategoriesService(
            IDeletableEntityRepository<RiddleCategory> riddlesCategoriesRepository)
        {
            this.riddlesCategoriesRepository = riddlesCategoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
            => this.riddlesCategoriesRepository
                .All()
                .To<T>()
                .ToList();
    }
}
