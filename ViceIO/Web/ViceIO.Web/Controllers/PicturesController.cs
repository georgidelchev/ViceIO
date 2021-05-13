using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
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
        [Breadcrumb("All Pictures", FromAction = "Index", FromController = typeof(HomeController))]
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
                Count = this.picturesService.GetCount(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Breadcrumb("Create Picture", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Create()
        {
            var viewModel = new CreatePictureInputModel()
            {
                Categories = this.picturesCategoriesService
                    .GetAll(),
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

            var userId = this.User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            var wwwrootPath = this.environment
                .WebRootPath;

            try
            {
                await this.picturesService
                    .CreateAsync(input, userId, $"{wwwrootPath}/system_images");
            }
            catch
            {
                return this.View("Error");
            }

            return this.Redirect("/Pictures/All");
        }

        [HttpGet]
        [Breadcrumb("Random Picture", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Random()
        {
            if (this.picturesService.GetCount() == 0)
            {
                return this.View("Error");
            }

            var viewModel = this.picturesService.GetRandom();

            return this.View(viewModel);
        }

        [Breadcrumb("Details", FromAction = "All", FromController = typeof(PicturesController))]
        public IActionResult Details(int id)
        {
            var viewModel = this.picturesService
                .Details(id);

            return this.View(viewModel);
        }
    }
}
