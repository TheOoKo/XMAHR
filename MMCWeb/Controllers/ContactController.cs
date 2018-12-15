using MMCWeb.Models;
using MMCWeb.Services;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MMCWeb.controller
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        private IUserMailer _userMailer;
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        public ContactController()
        {
            _userMailer = new UserMailer();
        }
        public ActionResult Index()
        {
            ViewBag.navInfo = "nav_contact";
            return View();
        }

        [HttpPost]
        public ActionResult SubmitContactInfo(ContactInfoModel contactInfo)
        {


            UserMailer.SendEmail(new ContactEmailInfo()
            {
                From = contactInfo.Email,
                To = "info@myanmarmedicalcouncil.org.mm",
                ViewName = "ContactInfo",
                Subject = "Contact to Myanmar Medical Council",
                Message = contactInfo.Message,
                Email = contactInfo.Email,
                Name = contactInfo.Name,
                Phone = contactInfo.Phone


            }).SendAsync();
            UserMailer.SendEmail(new ContactEmailInfo()
            {
                From = contactInfo.Email,
                To = "yarzarminnhtoo@gmail.com",
                ViewName = "ContactInfo",
                Subject = "Contact to Myanmar Medical Council",
                Message = contactInfo.Message,
                Email = contactInfo.Email,
                Name = contactInfo.Name,
                Phone = contactInfo.Phone


            }).SendAsync();
            return Json("success", JsonRequestBehavior.AllowGet);

        }
    }
}
