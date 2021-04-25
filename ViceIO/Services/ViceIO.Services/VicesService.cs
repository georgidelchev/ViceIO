using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Services
{
    public class VicesService : IVicesService
    {
        private readonly IDeletableEntityRepository<Vice> vicesRepository;

        public VicesService(IDeletableEntityRepository<Vice> vicesRepository)
        {
            this.vicesRepository = vicesRepository;
        }

        public Task CreateAsync(CreateViceInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<GetAllVicesViewModel> GetAll()
        {
            var vices = this.vicesRepository
                .All()
                .Select(v => new GetAllVicesViewModel
                {
                    AddedByUserEmail = v.AddedByUser.Email,
                    CategoryName = v.Category.Name,
                    Content = v.Content,
                    CreatedOn = v.CreatedOn,
                    Id = v.Id,
                })
                .ToList();

            return vices;
        }

        public GetRandomViceViewModel GetRandom()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            var vicesCount = this.vicesRepository
                .All()
                .Count();

            return vicesCount;
        }

        public GetViceBaseViewModel GetById(int viceId)
        {
            var vice = this.vicesRepository
                .All()
                .Where(v => v.Id == viceId)
                .Select(v => new GetViceBaseViewModel()
                {
                    AddedByUserEmail = v.AddedByUser.Email,
                    CategoryName = v.Category.Name,
                    Content = v.Content,
                    CreatedOn = v.CreatedOn,
                    Id = v.Id,
                })
                .FirstOrDefault();

            return vice;
        }
    }
}
