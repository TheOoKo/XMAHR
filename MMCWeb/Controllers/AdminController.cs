//using Core.Interfaces;
//using Infra.Repository;
//using MMCWeb.Helpers;
//using MMCWeb.Helpers.FilterSorterUtilities;
//using Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.Mvc;
//using MMCWeb.Models;

//namespace MMCWeb.Controllers
//{
//    public class AdminController : Controller
//    {
//        IRepository<tbArticle> _article;
//        IRepository<tbAccount> _account;
//        IRepository<tbPhoto> _photo;
//        MMCDBContext _dbContext;

//        public AdminController()
//        {
//            _dbContext = new MMCDBContext();
//            _article = new Repository<tbArticle>(_dbContext);
//            _account = new Repository<tbAccount>(_dbContext);
//            _photo = new Repository<tbPhoto>(_dbContext);
//        }

//        [AuthorizeUser(AccountRole = "Admin")]
//        public ActionResult Index()
//        {

//            return RedirectToAction("Articles");
//        }

//        [AuthorizeUser(AccountRole = "Admin")]
//        public ActionResult Articles()
//        {
//            return View();
//        }

//        [AuthorizeUser(AccountRole = "Admin")]
//        public ActionResult Accounts()
//        {
//            return View();
//        }

//        [HttpGet]
//        public JsonResult getAllAccounts(int take, int skip, int page, int pageSize)
//        {
//            var sorterCollection = SorterCollection.BuildCollection(Request);
//            var filterCollection = FilterCollection.BuildCollection(Request);


//            var accounts = from a in _account.GetAll() where a.IsDeleted != true orderby a.ID descending select a;

//            var filteredAccounts = accounts.MultipleFilter(filterCollection.Filters);
//            var sortedAccounts = filteredAccounts.MultipleSort(sorterCollection.Sorters).ToList();
//            var count = sortedAccounts.Count();
//            var data = (from v in sortedAccounts.Skip(skip)
//                            .Take(pageSize)
//                        select v).AsQueryable();

//            var jsonData = new { total = count, data };
//            return Json(jsonData, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public JsonResult UpdateAccount(tbAccount model)
//        {
//            if (model.ID == 0)
//            {
//                model.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
//                model.IsDeleted = false;
//                _account.Insert(model);
//            }
//            else
//            {
//                tbAccount oldModel = _account.GetById(model.ID);
//                oldModel.Name = model.Name;
//                oldModel.Username = model.Username;
//                oldModel.Password = model.Password;
//                oldModel.Role = model.Role;
//                oldModel.Phone = model.Phone;
//                oldModel.Email = model.Email;
//                oldModel.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
//                _account.Update(oldModel);
//            }

//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult accountDelete(int aid)
//        {
//            tbAccount oldModel = _account.GetById(aid);
//            oldModel.IsDeleted = true;
//            _account.Update(oldModel);

//            return Json(oldModel, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult getAllArticles(int take, int skip, int page, int pageSize)
//        {
//            var sorterCollection = SorterCollection.BuildCollection(Request);
//            var filterCollection = FilterCollection.BuildCollection(Request);


//            var articles = from a in _article.GetAll() where a.IsDeleted != true orderby a.ID descending select a;

//            var filteredArticles = articles.MultipleFilter(filterCollection.Filters);
//            var sortedArticles = filteredArticles.MultipleSort(sorterCollection.Sorters).ToList();
//            var count = sortedArticles.Count();
//            var data = (from v in sortedArticles.Skip(skip)
//                            .Take(pageSize)
//                        select v).AsQueryable();

//            var jsonData = new { total = count, data };
//            return Json(jsonData, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public JsonResult UpdateArticle(tbArticle model)
//        {
//            tbAccount account = _account.GetById(getAccountId());

//            if (model.ID == 0)
//            {
//                model.PostedDate = MyExtension.getLocalTime(DateTime.UtcNow);
//                model.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
//                model.IsDeleted = false;
//                model.IsPublished = false;
//                //Important
//                model.AuthorID = account.ID;
//                model.AuthorName = account.Name;
//                _article.Insert(model);
//            }
//            else
//            {
//                tbArticle oldModel = _article.GetById(model.ID);
//                oldModel.Title = model.Title;
//                oldModel.Body = model.Body;
//                oldModel.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
//                _article.Update(oldModel);
//            }

//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult changeArticleStatus(int aid, bool aStatus)
//        {
//            tbArticle oldModel = _article.GetById(aid);
//            oldModel.IsPublished = aStatus;
//            _article.Update(oldModel);

//            return Json(oldModel, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult articleDelete(int aid)
//        {
//            tbArticle oldModel = _article.GetById(aid);
//            oldModel.IsDeleted = true;
//            _article.Update(oldModel);

//            return Json(oldModel, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult getPhotoListByArticleId(int aid)
//        {
//            var result = _photo.GetAll().Where(a => a.ArticleID == aid).ToList();
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult getAllArticlesHome()
//        {
//            var result = _article.GetAll().Where(a => a.IsPublished == true && a.IsDeleted != true).OrderByDescending(a => a.ID).AsQueryable();
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public JsonResult getAllPhotoByArticleId(int aid)
//        {
//            var result = _photo.GetAll().Where(p => p.ArticleID == aid).AsQueryable();
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        #region supCookie

//        public void SetCookie(string CookieName, int AccountId, string UserName, string Role)
//        {
//            HttpCookie myCookie = HttpContext.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);
//            myCookie.Values["AccountID"] = AccountId.ToString();
//            myCookie.Values["UserName"] = UserName;
//            myCookie.Values["Role"] = Role;
//            myCookie.Expires = MyExtension.getLocalTime(DateTime.UtcNow).AddDays(30);
//            HttpContext.Response.Cookies.Add(myCookie);
//        }
//        public void fillcookie()
//        {
//            String username = null;
//            username = User.Identity.Name;
//            tbAccount account = _account.Query(m => m.Username == username).FirstOrDefault();
//            SetCookie("accCookie", account.ID, account.Username, account.Role);
//        }

//        public AccountCookie getAccount()
//        {
//            AccountCookie sc = new AccountCookie();
//            if (User.Identity.IsAuthenticated)
//            {
//                if (Request.Cookies["accCookie"] != null)
//                {
//                    sc.AccountID = Convert.ToInt32(Request.Cookies["accCookie"]["AccountID"]);
//                    sc.Role = Request.Cookies["accCookie"]["Role"];
//                }
//                else
//                {
//                    fillcookie();
//                    sc.AccountID = Convert.ToInt32(Request.Cookies["accCookie"]["AccountID"]);
//                    sc.Role = Request.Cookies["accCookie"]["Role"];
//                }
//            }
//            return sc;
//        }

//        public int getAccountId()
//        {
//            AccountCookie sc = getAccount();
//            return sc.AccountID;
//        }
//        public string getAccountRole()
//        {
//            AccountCookie mc = getAccount();
//            return mc.Role;
//        }
//        #endregion

//    }
//}