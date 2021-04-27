using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.VicesVotes;

namespace ViceIO.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViceVotesController : Controller
    {
        private readonly IViceVotesService viceVotesService;

        public ViceVotesController(IViceVotesService viceVotesService)
        {
            this.viceVotesService = viceVotesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostViceVoteResponseModel>> Post(PostViceVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.viceVotesService.SetVoteAsync(input.ViceId, userId, input.Value);

            var averageVotes = this.viceVotesService
                .GetAverageVotes(input.ViceId);

            return new PostViceVoteResponseModel() { AverageVote = averageVotes };
        }
    }
}
