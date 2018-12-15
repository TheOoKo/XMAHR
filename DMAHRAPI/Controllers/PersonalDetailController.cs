using Data.Models;
using Data.ViewModels;
using DMAHRAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMAHRAPI.Controllers
{
    public class PersonalDetailController : ApiController
    {
        GovernmentDbContext dbContext;
        private PersonalRepository personalRepo = null;
        private DivisionRepository divisionRepo = null;
        private SectionRepository sectionRepo = null;
        private PersonalDetailRepository personalDetailRepo = null;
        public PersonalDetailController()
        {
            dbContext = new GovernmentDbContext();
            personalRepo = new PersonalRepository(dbContext);
            divisionRepo = new DivisionRepository(dbContext);
            sectionRepo = new SectionRepository(dbContext);
            personalDetailRepo = new PersonalDetailRepository(dbContext);
        }

        //Education PersonalID
        [Route("api/PersonalDetail/GetPersonal")]
        [HttpGet]
        public HttpResponseMessage GetPersonal(HttpRequestMessage request, int Id)
        {
            Personal personal = personalRepo.GetWithoutTracking().Where(a => a.PersonalID == Id && a.IsDeleted==false).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, personal);
        }





        [Route("api/PersonalDetail/GetPersonalById")]
        [HttpGet]

        public HttpResponseMessage GetPersonalById(HttpRequestMessage request, int Id)
        {

            PersonalDivisionSection personal = (from per in personalRepo.GetWithoutTracking().Where(a => a.IsDeleted != true && a.PersonalID == Id)
                                                join div in divisionRepo.GetWithoutTracking()
                                                on per.DivisionID equals div.DivisionID
                                                join sec in sectionRepo.GetWithoutTracking()
                                                on per.SectionID equals sec.SectionID
                                                select new PersonalDivisionSection
                                                {
                                                    persoanl = per,
                                                    division = div,
                                                    section = sec,
                                                }).FirstOrDefault();
            List<Division> division = divisionRepo.Get().ToList();
            List<Section> section = sectionRepo.Get().ToList();
            PersonalData personaldata = new PersonalData();
            personaldata.personalDivisionSection = personal;
            personaldata.divisionData = division;
            personaldata.sectionData = section;


            return Request.CreateResponse(HttpStatusCode.OK, personaldata);
        }


      [Route("api/PersonalDetail/UpsertPersonal")]  
      [HttpPost]

        public HttpResponseMessage upsertPersonal(HttpRequestMessage request, Personal personal)
        {

            Personal updateEntity = null;
            if (personal.PersonalID > 0)
            {
                personal.IsDeleted = false;
                updateEntity = personalDetailRepo.UpdatewithObj(personal);
            }
            return Request.CreateResponse<Personal>(HttpStatusCode.OK, updateEntity);
        }

      

    }
}
