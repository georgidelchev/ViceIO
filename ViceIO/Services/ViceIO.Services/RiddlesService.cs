using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Common;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Riddles;

namespace ViceIO.Services
{
    public class RiddlesService : IRiddlesService
    {
        private readonly IDeletableEntityRepository<Riddle> riddlesRepository;
        private readonly Random random;

        public RiddlesService(IDeletableEntityRepository<Riddle> riddlesRepository, Random random)
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

        public IEnumerable<GetAllRiddlesViewModel> GetAll()
        {
            var riddles = this.riddlesRepository
                .All()
                .Select(r => new GetAllRiddlesViewModel()
                {
                    AddedByUserEmail = r.AddedByUser.Email,
                    CategoryName = r.Category.Name,
                    Content = r.Content,
                    Answer = r.Answer,
                    CreatedOn = r.CreatedOn,
                    Id = r.Id,
                    AddedByUserId = r.AddedByUserId,
                    AverageVote = r.RiddleVotes.Count == 0 ? 0 : r.RiddleVotes.Average(vv => vv.Value),
                })
                .ToList();

            return riddles;
        }

        public GetRiddleBaseViewModel GetRandom()
        {
            var randomRiddle = this.riddlesRepository
                .All()
                .OrderBy(r => Guid.NewGuid())
                .Skip(this.random.Next(GlobalConstants.GetRandomStartingIndex, this.riddlesRepository.All().Count()))
                .Select(r => new GetRiddleBaseViewModel()
                {
                    AddedByUserEmail = r.AddedByUser.Email,
                    CategoryName = r.Category.Name,
                    Content = r.Content,
                    Answer = r.Answer,
                    CreatedOn = r.CreatedOn,
                    Id = r.Id,
                    AddedByUserId = r.AddedByUserId,
                })
                .FirstOrDefault();

            return randomRiddle;
        }

        public int GetCount()
        {
            var riddlesCount = this.riddlesRepository
                .All()
                .Count();

            return riddlesCount;
        }

        public GetRiddleBaseViewModel GetById(int riddleId)
        {
            var riddle = this.riddlesRepository
                .All()
                .Where(r => r.Id == riddleId)
                .Select(r => new GetRiddleBaseViewModel()
                {
                    AddedByUserEmail = r.AddedByUser.Email,
                    CategoryName = r.Category.Name,
                    Content = r.Content,
                    Answer = r.Answer,
                    CreatedOn = r.CreatedOn,
                    Id = r.Id,
                    AddedByUserId = r.AddedByUserId,
                })
                .FirstOrDefault();

            return riddle;
        }
    }
}
