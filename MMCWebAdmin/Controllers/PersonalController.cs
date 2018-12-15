using Data.Models;
using Data.ViewModels;
using DMAHR.Models;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DMAHR.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            ViewBag.tags = new List<TagViewModel>()
            {
                new TagViewModel(){SearchTerm="*",SearchValue="*",Tag="All"},
                new TagViewModel(){SearchTerm="ByApproved",SearchValue="APPROVED",Tag="Approved"},
                new TagViewModel(){SearchTerm="ByDismissed",SearchValue="Dismissed",Tag="Dismissed"}
            };
            ViewBag.searchFilters = new string[] { "By Name", "By Licence No", "By Father Name" };
            ViewBag.sortFilters = new String[] { "By Name", "By Licence No", "By Updated" };

            return View();
        }

        public async Task<ActionResult> List(int pagesize = 2, int page = 1)
        {
            PagedListClient<Personal> result = await PersonalApiRequestHelper.GetPersonalWithPaging(pagesize, page);
            return PartialView("_list", result);

        }

        public async Task<ActionResult> _PersonalForm(string FormType, int ID)
        {
            Personal personal = new Personal();
            if (FormType == "Add")
            {
                return PartialView("_create", personal);
            }
            else
            {
                List<Division> result = await DivisionApiRequestHelper.GetDivisionName();
                return PartialView("_list", result);
            }
        }

        // Get Division
        public async Task<ActionResult> GetDivision()
        {
            List<Division> result = await DivisionApiRequestHelper.GetDivisionName();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Get Section
        public async Task<ActionResult> GetSection()
        {
            List<Section> result = await SectionApiRequestHelper.GetSectionName();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(Personal personal)
        {
            Personal result = await PersonalApiRequestHelper.UpSertPersonal(personal);
            if (result != null)
            {
                return Json("Index", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }


        }

        public async Task<ActionResult> PersonalDelete(int id)
        {
            Personal result = await PersonalApiRequestHelper.DeletePersonal(id);
            if (result != null)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }


        }
       


    }
}