using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViceIO.Common;
using ViceIO.Web.Controllers;

namespace ViceIO.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
