using System.Collections.Generic;
using System.Linq;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.VicesCategories;

namespace ViceIO.Services
{
    public class VicesCategoriesService : IVicesCategoriesService
    {
        private readonly IDeletableEntityRepository<ViceCategory> vicesCategoriesRepository;

        public VicesCategoriesService(IDeletableEntityRepository<ViceCategory> vicesCategoriesRepository)
        {
            this.vicesCategoriesRepository = vicesCategoriesRepository;
        }

        public IEnumerable<VicesCategoriesModel> GetAll()
        {
            var vicesCategories = this.vicesCategoriesRepository
                .All()
                .Select(vc => new VicesCategoriesModel
                {
                    Id = vc.Id,
                    Name = vc.Name,
                })
                .ToList();

            return vicesCategories;
        }
    }
}
