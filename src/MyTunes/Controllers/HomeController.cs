using MyTunes.Filters;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [LogginAction]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "MyTunes sera quien le de vuelta a iTunes ;-)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "para contratos envie un mensaje a @uzigula.";

            return View();
        }
    }
}
