using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Vices;
using ViceIO.Web.ViewModels.VicesCategories;

namespace ViceIO.Web.Controllers
{
    public class VicesController : Controller
    {
        private readonly IVicesService vicesService;
        private readonly IVicesCategoriesService vicesCategoriesService;

        public VicesController(
            IVicesService vicesService,
            IVicesCategoriesService vicesCategoriesService)
        {
            this.vicesService = vicesService;
            this.vicesCategoriesService = vicesCategoriesService;
        }

        [HttpGet]
        [Breadcrumb("All Vices", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new AllVicesListViewModel()
            {
                Vices = this.vicesService.GetAll<GetAllVicesViewModel>(id, 24),
                ItemsPerPage = 24,
                PageNumber = id,
                Count = this.vicesService.GetCount(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Breadcrumb("Create Vice", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Create()
        {
            var viewModel = new CreateViceInputModel
            {
                Categories = this.vicesCategoriesService.GetAll<VicesCategoriesModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.vicesService.CreateAsync(input, userId);

            return this.Redirect("/Vices/All");
        }

        [HttpGet]
        [Breadcrumb("Random Vice", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Random()
        {
            if (this.vicesService.GetCount() == 0)
            {
                return this.View("Error");
            }

            var viewModel = this.vicesService.GetRandom<GetRandomViceViewModel>();

            return this.View(viewModel);
        }

        [HttpGet]
        [Breadcrumb("Vice Details", FromAction = "All", FromController = typeof(VicesController))]
        public IActionResult Details(int id)
        {
            var viewModel = this.vicesService.GetDetails<GetViceDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
