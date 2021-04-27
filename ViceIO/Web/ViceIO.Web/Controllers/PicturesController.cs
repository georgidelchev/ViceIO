using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Web.Controllers
{
    public class PicturesController:Controller
    {
        private readonly IPicturesService picturesService;
        private readonly IPicturesCategoriesService picturesCategoriesService;

        public PicturesController(IPicturesService picturesService,
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
    }
}
