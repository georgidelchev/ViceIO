using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Vices;

namespace ViceIO.Web.Controllers
{
    public class VicesController : Controller
    {
        private readonly IVicesService vicesService;

        public VicesController(IVicesService vicesService)
        {
            this.vicesService = vicesService;
        }

        public IActionResult All()
        {
            var viewModel = new VicesListViewModel()
            {
                Vices = this.vicesService.GetAll(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateViceInputModel input)
        {
            return this.Redirect("Vices/All");
        }

        public IActionResult Random()
        {
            return this.View();
        }
    }
}
