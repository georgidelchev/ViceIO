using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using ViceIO.Web.ViewModels;

namespace ViceIO.Web.Controllers
{
    public class HomeController : Controller
    {
        [DefaultBreadcrumb("Home")]
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.View();
            }

            return this.Redirect("/Identity/Account/Login");
        }

        [Breadcrumb("Privacy")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
