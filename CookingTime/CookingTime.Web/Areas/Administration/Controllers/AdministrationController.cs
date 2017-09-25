using System.Web.Mvc;

namespace CookingTime.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Common.Constants.AdministratorRoleName)]
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}