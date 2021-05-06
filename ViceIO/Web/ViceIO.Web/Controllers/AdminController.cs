using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ViceIO.Web.Controllers
{
    [Authorize("Admin")]

    public class AdminController : Controller
    {
    }
}
