using Data.Models;
using Data.ViewModels;
using DMAHRAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMAHRAPI.Controllers
{
    public class PersonalController : ApiController
    {
        GovernmentDbContext dbContext;
        private PersonalRepository personalRepo = null;
        private DivisionRepository divisionRepo = null;
        private SectionRepository sectionRepo = null;


        public PersonalController()
        {
            dbContext = new GovernmentDbContext();
            personalRepo = new PersonalRepository(dbContext);
            divisionRepo = new DivisionRepository(dbContext);
            sectionRepo = new SectionRepository(dbContext);
        }
      [Route("api/Personal/list")]
      [HttpGet]
      public HttpResponseMessage list(HttpRequestMessage request,int pagesize=2,int page=1)
        {
            List<Personal> result = personalRepo.GetWithoutTracking().Where(a=>a.IsDeleted==false).ToList();
            var totalCount = result.Count();
            var totalpages = (int)Math.Ceiling((double)totalCount / pagesize);
            var dataList = result.Skip(pagesize * (page - 1)).Take(pagesize);
            PagedListServer<Personal> model = new PagedListServer<Personal>();
            model.Results = dataList.ToList();
            model.TotalCount = totalCount;
            model.TotalPages = totalpages;
            dbContext.Dispose();
            return request.CreateResponse<PagedListServer<Personal>>(HttpStatusCode.OK, model);
           
        }

        [Route("api/Personal/GetDivision")]
        [HttpGet]
        public HttpResponseMessage GetDivision(HttpRequestMessage request)
        {
            List<Division> result = divisionRepo.Get().ToList();
            return request.CreateResponse(HttpStatusCode.OK,result);

        }

        [Route("api/Personal/GetSection")]
        [HttpGet]
        public HttpResponseMessage GetSection(HttpRequestMessage request)
        {
            List<Section> result = sectionRepo.Get().ToList();
            return request.CreateResponse(HttpStatusCode.OK, result);
        }
        [Route("api/Personal/UpSertPersonal")]
        [HttpPost]
        public HttpResponseMessage UpSertPersonal(HttpRequestMessage request,Personal personal)
        {
            Personal UpdateEntity=null;


            personal.IsDeleted = false;

            UpdateEntity = personalRepo.AddWithGetObj(personal);


            return request.CreateResponse<Personal>(HttpStatusCode.OK,UpdateEntity);
        }

        [Route("api/Personal/DeletePersonal")]
        [HttpGet]
        public HttpResponseMessage Delete(HttpRequestMessage request,int Id)
        {
            Personal UpdateEntity = new Personal();
            Personal personal = personalRepo.Get().Where(a => a.PersonalID == Id).FirstOrDefault();
            personal.IsDeleted = true;
            UpdateEntity = personalRepo.UpdatewithObj(personal);

            return Request.CreateResponse<Personal>(HttpStatusCode.OK, UpdateEntity);

        }


    }
}
