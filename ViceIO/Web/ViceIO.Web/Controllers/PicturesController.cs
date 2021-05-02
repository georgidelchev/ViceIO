using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Web.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPicturesService picturesService;
        private readonly IPicturesCategoriesService picturesCategoriesService;

        public PicturesController(
            IPicturesService picturesService,
            IPicturesCategoriesService picturesCategoriesService)
        {
            this.picturesCategoriesService = picturesCategoriesService;
            this.picturesService = picturesService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new PicturesListViewModel()
            {
                Pictures = this.picturesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreatePictureInputModel()
            {
                Categories = this.picturesCategoriesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePictureInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.picturesService.CreateAsync(input, userId);

            return this.Redirect("/Pictures/All");
        }

        [HttpGet]
        public IActionResult Random()
        {
            var viewModel = this.picturesService.GetRandom();

            return this.View(viewModel);
        }
    }
}
