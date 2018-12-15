using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMCWeb.Models;
using Data.Models;
using Core.Interfaces;
using Infra.Repository;
using System.Web.Security;
using MMCWeb.Helpers;
using System;
using System.Collections.Generic;

namespace MMCWeb.Controllers
{
    public class AccountController : Controller
    {
        
        IRepository<Account> _account;
        GovernmentDbContext _dbContext;

        protected override void Dispose(bool disposing)
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public AccountController()
        {
            _dbContext = new GovernmentDbContext();
            _account = new Repository<Account>(_dbContext);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                Account result = _account.Query(u => u.Username == member.Username && u.Password == member.Password).FirstOrDefault();
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(member.Username, member.Remember);
                    SetCookie("accCookie", result.ID, result.Username, result.Role);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Unauthorize = "Unauthorize";
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            RemoveCookie("accCookie");

            Response.Cookies["accCookie"].Expires = MyExtension.getLocalTime(DateTime.UtcNow).AddYears(-30);
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        

        public ActionResult Setting()
        {

            return View();
        }



        #region supCookie

        public void SetCookie(string CookieName, int AccountId, string UserName, string Role)
        {
            HttpCookie myCookie = HttpContext.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);
            myCookie.Values["AccountID"] = AccountId.ToString();
            myCookie.Values["UserName"] = UserName;
            myCookie.Values["Role"] = Role;
            myCookie.Expires = MyExtension.getLocalTime(DateTime.UtcNow).AddDays(30);
            HttpContext.Response.Cookies.Add(myCookie);
        }
        public void fillcookie()
        {
            String username = null;
            username = User.Identity.Name;
            Account account = _account.Query(m => m.Username == username).FirstOrDefault();
            SetCookie("accCookie", account.ID, account.Username, account.Role);
        }

        public AccountCookie getAccount()
        {
            AccountCookie sc = new AccountCookie();
            if (User.Identity.IsAuthenticated)
            {
                if (Request.Cookies["accCookie"] != null)
                {
                    sc.AccountID = Convert.ToInt32(Request.Cookies["accCookie"]["AccountID"]);
                    sc.Role = Request.Cookies["accCookie"]["Role"];
                }
                else
                {
                    fillcookie();
                    sc.AccountID = Convert.ToInt32(Request.Cookies["accCookie"]["AccountID"]);
                    sc.Role = Request.Cookies["accCookie"]["Role"];
                }
            }
            return sc;
        }

        public int getAccountId()
        {
            AccountCookie sc = getAccount();
            return sc.AccountID;
        }
        public string getAccountRole()
        {
            AccountCookie mc = getAccount();
            return mc.Role;
        }
        #endregion
        public bool RemoveCookie(String CookieName)
        {
            if (HttpContext.Request.Cookies[CookieName] != null)
            {
                HttpCookie myCookie = HttpContext.Request.Cookies[CookieName];
                myCookie.Expires = MyExtension.getLocalTime(DateTime.UtcNow).AddDays(-1);
                HttpContext.Response.Cookies.Add(myCookie);
                return true;
            }
            return false;
        }
    }

    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string AccountRole { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            string privilegeLevels = string.Join("", getAccountRole(httpContext.User.Identity.Name.ToString()));

            List<string> roles = this.AccountRole.Split(',').Select(p => p.Trim()).ToList();
            foreach (var role in roles)
            {
                if (privilegeLevels.Contains(role))
                {
                    return true;
                }
            }
            return false;
        }

        public string getAccountRole(string username = null)
        {
            Account supobj = null;
            using (var db = new GovernmentDbContext())
            {
                supobj = db.Accounts.Where(m => m.Username == username).FirstOrDefault();
            }
            return supobj.Role;
        }

    }
}