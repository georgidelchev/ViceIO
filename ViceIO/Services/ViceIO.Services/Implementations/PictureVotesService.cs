using System.Linq;
using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;

namespace ViceIO.Services.Services
{
    public class PictureVotesService : IPictureVotesService
    {
        private readonly IRepository<PictureVote> pictureVotesRepository;

        public PictureVotesService(
            IRepository<PictureVote> pictureVotesRepository)
        {
            this.pictureVotesRepository = pictureVotesRepository;
        }

        public async Task SetVoteAsync(int pictureId, string userId, byte value)
        {
            if (this.pictureVotesRepository
                .AllAsNoTracking()
                .Any(pv => pv.PictureId == pictureId &&
                           pv.UserId == userId))
            {
                return;
            }

            var pictureVote = new PictureVote()
            {
                PictureId = pictureId,
                UserId = userId,
                Value = value,
            };

            await this.pictureVotesRepository.AddAsync(pictureVote);
            await this.pictureVotesRepository.SaveChangesAsync();
        }

        public double GetAverageVotes(int pictureId)
        {
            var averageVotes = this.pictureVotesRepository
                .All()
                .Where(pv => pv.PictureId == pictureId)
                .Average(p => p.Value);

            return averageVotes;
        }
    }
}
