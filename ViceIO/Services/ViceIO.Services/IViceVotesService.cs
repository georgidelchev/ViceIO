using System.Threading.Tasks;

namespace ViceIO.Services
{
    public interface IViceVotesService
    {
        Task SetVoteAsync(int viceId, string userId, byte value);

        double GetAverageVotes(int viceId);
    }
}
