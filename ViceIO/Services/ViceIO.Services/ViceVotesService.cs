using System.Linq;
using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;

namespace ViceIO.Services
{
    public class ViceVotesService : IViceVotesService
    {
        private readonly IRepository<ViceVote> vicesVotesRepository;

        public ViceVotesService(IRepository<ViceVote> vicesVotesRepository)
        {
            this.vicesVotesRepository = vicesVotesRepository;
        }

        public async Task SetVoteAsync(int viceId, string userId, byte value)
        {
            if (this.vicesVotesRepository
                .AllAsNoTracking()
                .Any(vv => vv.ViceId == viceId &&
                           vv.UserId == userId))
            {
                return;
            }

            var viceVote = new ViceVote()
            {
                UserId = userId,
                Value = value,
                ViceId = viceId,
            };

            await this.vicesVotesRepository.AddAsync(viceVote);
            await this.vicesVotesRepository.SaveChangesAsync();
        }

        public double GetAverageVotes(int viceId)
        {
            var averageVotes = this.vicesVotesRepository
                .All()
                .Where(vv => vv.ViceId == viceId)
                .Average(v => v.Value);

            return averageVotes;
        }
    }
}
