//using Core.Interfaces;
//using Infra.Repository;
//using Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MMCWeb.Controllers
//{
//    public class ArticlesController : Controller
//    {
//        IRepository<tbArticle> _article;
//        IRepository<tbAccount> _account;
//        IRepository<tbPhoto> _photo;
//        MMCDBContext _dbContext;

//        public ArticlesController()
//        {
//            _dbContext = new MMCDBContext();
//            _article = new Repository<tbArticle>(_dbContext);
//            _account = new Repository<tbAccount>(_dbContext);
//            _photo = new Repository<tbPhoto>(_dbContext);
//        }

//        public ActionResult Index()
//        {
//            ViewBag.Title = "MMC - News and Articles";
//            return View();
//        }

//        public ActionResult Detail(int id)
//        {
//            ViewBag.Title = "MMC - News and Article Detail";

//            tbArticle model = _article.GetById(id);

//            return View(model);
//        }

//    }
//}