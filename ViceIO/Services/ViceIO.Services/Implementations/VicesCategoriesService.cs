using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Services.Services
{
    public class VicesCategoriesService : IVicesCategoriesService
    {
        private readonly IDeletableEntityRepository<ViceCategory> vicesCategoriesRepository;

        public VicesCategoriesService(
            IDeletableEntityRepository<ViceCategory> vicesCategoriesRepository)
        {
            this.vicesCategoriesRepository = vicesCategoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
            => this.vicesCategoriesRepository
                .All()
                .To<T>()
                .ToList();
    }
}
