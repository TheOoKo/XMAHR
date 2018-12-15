using Core.Interfaces;
using Data.Models;
using Infra.Repository;
using System.Web.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.controller
{
    public class HomeController : Controller
    {
       // IRepository<tbLocation> _location;
        GovernmentDbContext _dbContext;
        protected override void Dispose(bool disposing)
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public HomeController()
        {
            _dbContext = new GovernmentDbContext();
          //  _location = new Repository<tbLocation>(_dbContext);
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_home";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.navInfo = "nav_home";
            return View();
        }
        public ActionResult Setup()
        {
            ViewBag.navInfo = "nav_home";
            return View();
        }
        public JsonResult GetStates()
        {
            //var results = _location.Query(l => l.Country == "Myanmar").Select(l => l.StateDivision).Distinct().ToList();
            //return Json(results, JsonRequestBehavior.AllowGet);
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTownships(string selectedState)
        {
            //  var results = _location.Query(l => l.Country == "Myanmar" && l.StateDivision == selectedState).Select(l => l.Township).ToList();
            //return Json(results, JsonRequestBehavior.AllowGet);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
