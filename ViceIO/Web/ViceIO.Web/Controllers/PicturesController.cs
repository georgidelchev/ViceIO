using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Web.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPicturesService picturesService;
        private readonly IPicturesCategoriesService picturesCategoriesService;
        private readonly IWebHostEnvironment environment;

        public PicturesController(
            IPicturesService picturesService,
            IPicturesCategoriesService picturesCategoriesService,
            IWebHostEnvironment environment)
        {
            this.picturesCategoriesService = picturesCategoriesService;
            this.picturesService = picturesService;

            this.environment = environment;
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new PicturesListViewModel()
            {
                Pictures = this.picturesService.GetAll(id, 12),
                ItemsPerPage = 12,
                PageNumber = id,
                RecipesCount = this.picturesService.GetCount(),
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
            var wwwrootPath = this.environment.WebRootPath;

            try
            {
                await this.picturesService.CreateAsync(input, userId, $"{wwwrootPath}/Pictures");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);

                return this.View(input);
            }

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
