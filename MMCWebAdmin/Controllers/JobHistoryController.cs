using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMAHR.Controllers
{
    public class JobHistoryController : Controller
    {
        // GET: JobHistory
        public ActionResult Index(int Id)
        {
            ViewBag.PersonalId = Id;
            return View();
        }
    }
}