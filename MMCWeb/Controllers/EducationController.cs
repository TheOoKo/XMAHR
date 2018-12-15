using System.Web.Mvc;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.controller
{
    public class EducationController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_med_education";
            return View();
        }
        public ActionResult Accreditation()
        {
            ViewBag.navInfo = "nav_med_education";
            return View();
        }
        public ActionResult EntryRequirement()
        {
            ViewBag.navInfo = "nav_med_education";
            return View();
        }
    }
}
