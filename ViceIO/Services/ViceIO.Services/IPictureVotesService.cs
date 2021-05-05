using System.Threading.Tasks;

namespace ViceIO.Services
{
    public interface IPictureVotesService
    {
        Task SetVoteAsync(int pictureId, string userId, byte value);

        double GetAverageVotes(int pictureId);
    }
}
