using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels;
using ViceIO.Web.ViewModels.PicturesVotes;

namespace ViceIO.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureVotesController : Controller
    {
        private readonly IPictureVotesService picturesVotesService;

        public PictureVotesController(IPictureVotesService picturesVotesService)
        {
            this.picturesVotesService = picturesVotesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVotesResponseModel>> Post(PostPictureVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.picturesVotesService.SetVoteAsync(input.PictureId, userId, input.Value);

            var averageVotes = this.picturesVotesService
                .GetAverageVotes(input.PictureId);

            return new PostVotesResponseModel() { AverageVote = averageVotes };
        }
    }
}
