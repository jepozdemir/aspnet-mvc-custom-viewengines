using System.Web.Mvc;

namespace CustomViewEngineSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomIndex()
        {
            ViewBag.Message = "Your custom view result.";

            return View();
        }
    }
}