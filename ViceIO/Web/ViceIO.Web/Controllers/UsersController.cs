using Microsoft.AspNetCore.Mvc;

namespace ViceIO.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Profile(string id)
        {
            return this.View();
        }
    }
}
