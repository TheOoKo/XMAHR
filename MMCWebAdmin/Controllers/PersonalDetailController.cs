using Data.Models;
using Data.ViewModels;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DMAHR.Controllers
{
    public class PersonalDetailController : Controller
    {
        // GET: PersonalDetail
        public ActionResult Index(int id)
        {
            ViewBag.PersonalId = id;
            return View();
        }

       
        public async Task<ActionResult> GetPersonalByID(string FormType, int id)
        {
           
            PersonalData result = await PersonalApiRequestHelper.GetPersonalById(id);

            return PartialView("_Detail", result);
        }

      

        public async Task<ActionResult> PersonalForm(string FormType, int id)
        {
            PersonalData result = new PersonalData();
            if(FormType == "Add")
            {
                return PartialView("_Form", result);
            }
            else
            {
                 result = await PersonalApiRequestHelper.GetPersonalById(id);

                return PartialView("_Form", result);
            }
        
        }
        [HttpPost]
        public async Task<ActionResult> UpsertPersonal(PersonalData personaldata)
        {

            Personal personal = new Personal();
            personal = personaldata.personalDivisionSection.persoanl;
            Personal result = await PersonalDetailApiRequestHelper.UpsertPersonal(personal);

            
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