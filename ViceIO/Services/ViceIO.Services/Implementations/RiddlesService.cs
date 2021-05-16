using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Common;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;
using ViceIO.Web.ViewModels.Riddles;

namespace ViceIO.Services
{
    public class RiddlesService : IRiddlesService
    {
        private readonly IDeletableEntityRepository<Riddle> riddlesRepository;
        private readonly Random random;

        public RiddlesService(
            IDeletableEntityRepository<Riddle> riddlesRepository,
            Random random)
        {
            this.riddlesRepository = riddlesRepository;
            this.random = random;
        }

        public async Task CreateAsync(CreateRiddleInputModel input, string userId)
        {
            var riddle = new Riddle()
            {
                Content = input.Content,
                Answer = input.Answer,
                CategoryId = input.CategoryId,
                AddedByUserId = userId,
            };

            await this.riddlesRepository.AddAsync(riddle);
            await this.riddlesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
            => this.riddlesRepository
                .All()
                .To<T>()
                .ToList();

        public T GetRandom<T>()
            => this.riddlesRepository
                .All()
                .OrderBy(r => Guid.NewGuid())
                .Skip(this.random.Next(GlobalConstants.GetRandomStartingIndex, this.GetCount()))
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.riddlesRepository
                .All()
                .Count();

        public T GetById<T>(int riddleId)
            => this.riddlesRepository
                .All()
                .Where(r => r.Id == riddleId)
                .To<T>()
                .FirstOrDefault();
    }
}
