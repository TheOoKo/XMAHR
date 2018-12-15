using Core.Interfaces;
using Infra.Repository;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MMCWeb.Helpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMCWeb.Controllers
{
    public class PhotoUploadController : Controller
    {
        //IRepository<tbArticle> _article;
        //IRepository<tbPhoto> _photo;
        GovernmentDbContext _dbContext;

        public PhotoUploadController()
        {
            _dbContext = new GovernmentDbContext();
            //_article = new Repository<tbArticle>(_dbContext);
            //_photo = new Repository<tbPhoto>(_dbContext);
        }

        public ActionResult uploadArticlePhoto(IEnumerable<HttpPostedFileBase> files, int aid)
        {
            

            if (files != null)
            {
                foreach (var file in files)
                {
                    string guid = Guid.NewGuid().ToString() + '.' + file.FileName.Split('.')[1];
                    
                    UploadBlodToAzure(string.Format("photo/{0}", guid), file);

                    //tbPhoto model = new tbPhoto()
                    //{
                    //    PhotoURL = guid,
                    //    ArticleID = aid
                    //};
                    //_photo.Insert(model);

                    //tbArticle oldModel = _article.GetById(aid);
                    //oldModel.Photo = guid;
                    //_article.Update(oldModel);

                }
            }
            return Content("");
        }

        [HttpGet]
        public JsonResult deleteArticlePhoto(int pId)
        {
            //tbPhoto oldModel = _photo.GetById(pId);
            //DeleteFromAzureBlob(oldModel.PhotoURL);
            //_photo.Delete(oldModel);
            return Json("Successful", JsonRequestBehavior.AllowGet);
        }

        private bool UploadBlodToAzure(string blobReference, HttpPostedFileBase file)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("mmc");
                BlobRequestOptions opt = new BlobRequestOptions
                {
                    SingleBlobUploadThresholdInBytes = 1048576,
                    ParallelOperationThreadCount = 4
                };
                blobClient.DefaultRequestOptions = opt;
                BlobContainerPermissions permissions = new BlobContainerPermissions()
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                container.SetPermissions(permissions);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);

                blockBlob.Properties.ContentType = file.ContentType;
                blockBlob.UploadFromStream(file.InputStream);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool DeleteFromAzureBlob(string filename)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("mmc");

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("photo/" + filename);
                blockBlob.Delete();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}