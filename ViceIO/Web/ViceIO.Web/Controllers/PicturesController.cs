using Microsoft.AspNetCore.Mvc;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Web.Controllers
{
    public class PicturesController
    {
        private readonly IPicturesService picturesService;
        private readonly IPicturesCategoriesService picturesCategoriesService;

        public PicturesController(IPicturesService picturesService, IPicturesCategoriesService picturesCategoriesService)
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
    }
}
