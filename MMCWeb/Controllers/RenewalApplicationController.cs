using Core.Interfaces;
using Data.Models;
using Infra.Repository;
using System;
using System.Web.Mvc;
using System.Linq;
using MMCWeb.Models;
using MMCWeb.Services;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.controller
{
    public class RenewalApplicationController : Controller
    {
        private IUserMailer _userMailer;
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
       // IRepository<tbRenewalPractitionerApplication> _renewalRepo;
        GovernmentDbContext _dbContext;
        public RenewalApplicationController()
        {
            _userMailer = new UserMailer();
            _dbContext = new GovernmentDbContext();
           // _renewalRepo = new Repository<tbRenewalPractitionerApplication>(_dbContext);
        }
        // GET: /<controller>/
      
        //public ActionResult ConfirmationInfo()
        //{
        //    var obj = _renewalRepo.Query(a => a.IsDeleted != true).FirstOrDefault();
        //    RenewalApplicationEmailInfo info = new RenewalApplicationEmailInfo()
        //    {
        //        Accesstime = obj.Accesstime,
        //        Name = obj.Name,
        //        Code = obj.Code,
        //        CurrentAddress = obj.CurrentAddress,
        //        Degree = obj.Degree,
        //        Email = obj.Email,
        //        GraduationYear = obj.GraduationYear,
        //        Township = obj.Township,
        //        StateDivision = obj.StateDivision,
        //        NRC = obj.NRC
        //    };
        //    return View(info);
        //}
        public ActionResult Status()
        {
            return View();
        }
        public ActionResult New()
        {
            ViewBag.navInfo = "nav_new";
            return View();
        }

        public ActionResult SendConfirmationInfo(string button, int id)
        {
            //if (button == "send")
            //{
            //    var obj = _renewalRepo.Query(a => a.ID == id && a.Source == "ONLINE" && a.IsDeleted != true).FirstOrDefault();
            //    if (obj != null)
            //    {
            //        SendEmail(obj);
            //        return PartialView("_View", obj);
            //    }
            //    return Json("Error!", JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
                return Json("Redirect", JsonRequestBehavior.AllowGet);
            //}
        }
        //public void SendEmail(tbRenewalPractitionerApplication obj)
        public void SendEmail()
        {
            //UserMailer.SendEmail(new RenewalApplicationEmailInfo()
            //{
            //    From = "info@myanmarmedicalcouncil.org.mm",
            //    To = obj.Email,
            //    ViewName = "RenewalConfirmationEmailInfo",
            //    Subject = "Confirmation of Renewal Application",
            //    Accesstime = obj.Accesstime,
            //    Name = obj.Name,
            //    Code = obj.Code,
            //    CurrentAddress = obj.CurrentAddress,
            //    Degree = obj.Degree,
            //    Email = obj.Email,
            //    GraduationYear = obj.GraduationYear,
            //    Township = obj.Township,
            //    StateDivision = obj.StateDivision,
            //    NRC = obj.NRC,
            //    LicenseNo = obj.LicenseNo,
            //    PostalService = obj.PostalService,
            //    Phone = obj.Phone


            //}).SendAsync();
        }
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_renewal";
            return View();
        }

        //public ActionResult Confrim(string button, tbRenewalPractitionerApplication model)
        public ActionResult Confrim(string button)
        {
            //if (button == "edit")
            //{
            //    var obj = _renewalRepo.Query(a => a.ID == model.ID && a.Source == "ONLINE" && a.IsDeleted != true).FirstOrDefault();
            //    return PartialView("_Edit", obj);
            //}
            //else
            //{
                //tbRenewalPractitionerApplication result;
                //var obj = _renewalRepo.Query(a => a.ID == model.ID && a.Source == "ONLINE" && a.IsDeleted != true).FirstOrDefault();
                //if (obj != null)
                //{
                //    obj.Status = "CONFIRMED";
                //    result = _renewalRepo.UpdateComplete(model, obj);
                //    SendEmail(obj);
                //    return PartialView("_View", result);
                //}
                return Json("Error!",JsonRequestBehavior.AllowGet);

           // }
        }
        [HttpPost]
        //public ActionResult Edit(tbRenewalPractitionerApplication model)
        public ActionResult Edit()
        {
        //    if (ModelState.IsValid)
        //    {
        //        tbRenewalPractitionerApplication result;
        //        var obj = _renewalRepo.Query(a => a.LicenseNo == model.LicenseNo && a.IsDeleted != true).FirstOrDefault();
        //        if (obj != null)
        //        {
        //            if (obj.Status == "CONFIRMED")
        //            {
        //                return PartialView("_View", obj);
        //            }
        //            obj.Status = "APPLIED";
        //            obj.Accesstime = DateTime.Now;
        //            obj.CurrentAddress = model.CurrentAddress;
        //            obj.Degree = model.Degree;
        //            obj.Email = model.Email;
        //            obj.GraduationYear = model.GraduationYear;
        //            obj.LicenseNo = model.LicenseNo;
        //            obj.Name = model.Name;
        //            obj.NRC = model.NRC;
        //            obj.Occupation = model.Occupation;
        //            obj.Phone = model.Phone;
        //            obj.Source = model.Source;
        //            obj.StateDivision = model.StateDivision;
        //            obj.Township = model.Township;
        //            obj.Source = "ONLINE";
        //            result = _renewalRepo.UpdateComplete(model, obj);
        //        }
        //        else
        //        {
        //            int lgvalue = 0;
        //            if (_renewalRepo.Query(a => a.IsDeleted != true).Select(a => a.ID).Count() > 0)
        //            {
        //                lgvalue = _renewalRepo.Query(a => a.IsDeleted != true).Select(a => a.CodeIndex ?? 0).Max() + 1;
                        
        //            }
        //            else
        //            {
        //                lgvalue = 1;
        //            }
        //            model.Status = "APPLIED";
        //            model.CodeIndex = lgvalue;
        //            model.Code = "RN-".getCode(lgvalue, "000000");
        //            model.Accesstime = DateTime.Now;
        //            model.IsDeleted = false;
        //            model.Source = "ONLINE";
        //            result = _renewalRepo.InsertReturn(model);
        //        }
                
        //        if (result != null)
        //        {
        //            return PartialView("_Confirm", result);
        //        }
        //        else
        //        {
        //            return Json("Error!", JsonRequestBehavior.AllowGet);
        //        }
        //    }
            return Json("Error!", JsonRequestBehavior.AllowGet);
        }

    }
}
