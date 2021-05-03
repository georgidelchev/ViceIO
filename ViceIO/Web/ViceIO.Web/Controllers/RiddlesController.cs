﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Riddles;

namespace ViceIO.Web.Controllers
{
    public class RiddlesController : Controller
    {
        private readonly IRiddlesService riddlesService;
        private readonly IRiddlesCategoriesService riddlesCategoriesService;

        public RiddlesController(IRiddlesService riddlesService, IRiddlesCategoriesService riddlesCategoriesService)
        {
            this.riddlesService = riddlesService;
            this.riddlesCategoriesService = riddlesCategoriesService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new RiddlesListViewModel()
            {
                Riddles = this.riddlesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateRiddleInputModel()
            {
                Categories = this.riddlesCategoriesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRiddleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await this.riddlesService.CreateAsync(input, userId);

            return this.Redirect("/Riddles/All");
        }

        [HttpGet]
        public IActionResult Random()
        {
            var viewModel = this.riddlesService.GetRandom();

            return this.View(viewModel);
        }
    }
}
