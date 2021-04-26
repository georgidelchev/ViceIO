using System;
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
        private readonly Random random;

        public VicesService(IDeletableEntityRepository<Vice> vicesRepository, Random random)
        {
            this.vicesRepository = vicesRepository;
            this.random = random;
        }

        public async Task CreateAsync(CreateViceInputModel input, string userId)
        {
            var vice = new Vice()
            {
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
                Content = input.Content,
            };

            await this.vicesRepository.AddAsync(vice);
            await this.vicesRepository.SaveChangesAsync();
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
                    AddedByUserId = v.AddedByUserId,
                })
                .ToList();

            return vices;
        }

        public GetRandomViceViewModel GetRandom()
        {
            var randomVice = this.vicesRepository
                .All()
                .OrderBy(v => Guid.NewGuid())
                .Skip(this.random.Next(1, this.vicesRepository.All().Count()))
                .Select(v => new GetRandomViceViewModel()
                {
                    AddedByUserEmail = v.AddedByUser.Email,
                    CategoryName = v.Category.Name,
                    Content = v.Content,
                    CreatedOn = v.CreatedOn,
                    Id = v.Id,
                    AddedByUserId = v.AddedByUserId,
                })
                .FirstOrDefault();

            return randomVice;
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
