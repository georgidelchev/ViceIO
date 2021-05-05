using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Web.Controllers
{
    public class VicesController : Controller
    {
        private readonly IVicesService vicesService;
        private readonly IVicesCategoriesService vicesCategoriesService;

        public VicesController(IVicesService vicesService, IVicesCategoriesService vicesCategoriesService)
        {
            this.vicesService = vicesService;
            this.vicesCategoriesService = vicesCategoriesService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new VicesListViewModel()
            {
                Vices = this.vicesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateViceInputModel
            {
                Categories = this.vicesCategoriesService.GetAll(),
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
        public IActionResult Random()
        {
            if (this.vicesService.GetCount() == 0)
            {
                return this.View("Error");
            }

            var viewModel = this.vicesService.GetRandom();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
