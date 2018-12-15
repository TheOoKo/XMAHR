using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Infra.Helper;

namespace DMAHR.Controllers
{
    public class EducationHistoryController : Controller
    {
        // GET: EducationHistory
        public async Task<ActionResult> Index(int Id)
        {
            ViewBag.PersonalId = Id;
            Personal result = await PersonalApiRequestHelper.GetPersonal(Id);
            //if (result == null)
            //{
            //    return PartialView("_NoEduHistory");
            //}
            //else
            //{
            //    return View(result);
            //}

            return View(result);
        }


        public async Task<ActionResult> GetHistory(int id)
        {
            EduHistory result = await EduHistoryApiRequestHelper.GetEduHistory(id);
            if(result !=null)
            {
                return PartialView("_Detail", result);
            }
            else
            {
                //return PartialView("_Detail", result);
                return PartialView("_NoEduHistory");
            }
          


        }

        public async Task<ActionResult> UpsertEducation(string FormType,int Id)
        {
            EduHistory eduHistory = new EduHistory();
            if(FormType == "Add")
            {
                eduHistory.PersonalID = Id;
                return PartialView("_Form",eduHistory);
            }
            else
            {
                eduHistory = await EduHistoryApiRequestHelper.GetEduHistoryId(Id);
                return PartialView("_Form", eduHistory);
            }
        }
        public async Task<ActionResult> UpsertEduHistory(EduHistory educationdata)
        {
            EduHistory result = await EduHistoryApiRequestHelper.UpsertEduHistory(educationdata);
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