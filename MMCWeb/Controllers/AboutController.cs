using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.Views.Home
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_home";
            return View();
        }
    }
}
