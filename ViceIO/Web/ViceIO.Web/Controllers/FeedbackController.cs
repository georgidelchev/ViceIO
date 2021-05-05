using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Web.Controllers
{
    public class FeedbackController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateFeedbackInputModel input, string userId)
        {

        }

    }
}
