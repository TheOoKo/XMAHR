using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.controller
{
    public class InformationController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Arbitration()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Goodstanding()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Recognition()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Licencing()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
        public ActionResult Relationship()
        {
            ViewBag.navInfo = "nav_information";
            return View();
        }
    }
}
