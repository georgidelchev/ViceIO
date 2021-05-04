using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace ViceIO.Web.Controllers
{
    public class UsersController : Controller
    {
        [Breadcrumb("Profile", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Profile(string id)
        {
            return this.View();
        }
    }
}
