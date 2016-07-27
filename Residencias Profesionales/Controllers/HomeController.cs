using System.Web.Mvc;

namespace Residencias.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Procedimiento de Residencias Profesionales del Instituto Tecnológico Superior de Escárcega";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Francisco Salvador Ballina Sánchez";

            return View();
        }
    }
}