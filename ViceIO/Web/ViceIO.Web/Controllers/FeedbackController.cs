<<<<<<< Updated upstream
﻿using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
=======
﻿using Microsoft.AspNetCore.Authorization;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using ViceIO.Data.Models;
using ViceIO.Services;
using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;
        private readonly UserManager<ApplicationUser> userManager;

        public FeedbackController(
            IFeedbackService feedbackService,
            UserManager<ApplicationUser> userManager)
        {
            this.feedbackService = feedbackService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Breadcrumb("Feedback", FromAction = "Index", FromController = typeof(HomeController))]
        public async Task<IActionResult> Create()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new CreateFeedbackInputModel()
            {
                Email = user.Email,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

<<<<<<< Updated upstream
            await this.feedbackService.CreateAsync(input, userId);

            return this.Redirect("/");
=======
>>>>>>> Stashed changes
        }
    }
}
