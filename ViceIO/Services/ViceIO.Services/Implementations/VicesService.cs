using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Common;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;
using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Services
{
    public class VicesService : IVicesService
    {
        private readonly Random random;
        private readonly IDeletableEntityRepository<Vice> vicesRepository;

        public VicesService(
            IDeletableEntityRepository<Vice> vicesRepository,
            Random random)
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

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
            => this.vicesRepository
                .All()
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

        public T GetRandom<T>()
            => this.vicesRepository
                .All()
                .OrderBy(v => Guid.NewGuid())
                .Skip(this.random.Next(GlobalConstants.GetRandomStartingIndex, this.GetCount()))
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.vicesRepository
                .All()
                .Count();

        public T GetDetails<T>(int viceId)
            => this.vicesRepository
                .All()
                .Where(v => v.Id == viceId)
                .To<T>()
                .FirstOrDefault();
    }
}
