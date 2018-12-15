using Data.Models;
using DMAHRAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMAHRAPI.Controllers
{
    public class EducationHistoryController : ApiController
    {
        GovernmentDbContext dbContext;
        private EduHistoryRepository EduHistoryRepo;

        public EducationHistoryController()
        {
            dbContext = new GovernmentDbContext();
            EduHistoryRepo = new EduHistoryRepository(dbContext);
        }

        // Detail Show
        [Route("api/EducationHistory/GetEduHistory")]
        [HttpGet]

        public HttpResponseMessage GetHistory(HttpRequestMessage request,int Id)
        {
            EduHistory result = EduHistoryRepo.GetWithoutTracking().Where(a => a.PersonalID == Id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // Form Show

        [Route("api/EducationHistory/GetEduHistoryId")]
        [HttpGet]
        public HttpResponseMessage GetEduHistory(HttpRequestMessage request,int Id)
        {
            EduHistory result = EduHistoryRepo.GetWithoutTracking().Where(a => a.EduHistoryID == Id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }


    [Route("api/EducationHistory/UpsertEducation")]
        [HttpPost]
        public HttpResponseMessage UpsertEducation(HttpRequestMessage request,EduHistory education)
        {
            EduHistory UpdateEntity = null;
            if(education.EduHistoryID != 0)
            {
                UpdateEntity = EduHistoryRepo.UpdatewithObj(education);
            }
            else
            {
                UpdateEntity = EduHistoryRepo.AddWithGetObj(education);
            }
           


            return request.CreateResponse<EduHistory>(HttpStatusCode.OK, UpdateEntity);

       
        }
    }
}
