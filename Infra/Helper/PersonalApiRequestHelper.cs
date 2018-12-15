using Data.Models;
using Data.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public class PersonalApiRequestHelper
    {
        public static async Task<PagedListClient<Personal>> GetPersonalWithPaging( int pagesize = 10, int page = 1)
        {

            string url = string.Format("api/Personal/list?pagesize={0}&page={1}" , pagesize, page);
            var data = await ApiRequest<PagedListServer<Personal>>.GetRequest(url);
            var model = new PagedListClient<Personal>();
            var pagedList = new StaticPagedList<Personal>(data.Results, page, pagesize, data.TotalCount);
            model.Results = pagedList;
            model.TotalCount = data.TotalCount;
            model.TotalPages = data.TotalPages;
            return model;

        }

        public static async Task<Personal> UpSertPersonal(Personal personal)
        {
            var url = "api/Personal/UpSertPersonal";
            Personal result = await ApiRequest<Personal>.PostRequest(url, personal);
            return result;

        }
        
        
        // for PersonalDetail
        //public static async Task<List<PersonalDivisionSection>> GetPersonalById(int id)
        //{
        //    string url = string.Format("/api/Personal/GetPersonalById?Id=" + id);
        //    List<PersonalDivisionSection> result = await ApiRequest<List<PersonalDivisionSection>>.GetRequest(url);
        //    return result;

        //}


        public static async Task<PersonalData> GetPersonalById(int id)
        {
            string url = string.Format("/api/PersonalDetail/GetPersonalById?Id=" + id);
            PersonalData result = await ApiRequest<PersonalData>.GetRequest(url);
            return result;

        }

        public static async Task<Personal> GetPersonal(int id)
        {
            string url = string.Format("/api/PersonalDetail/GetPersonal?Id=" + id);
            Personal result = await ApiRequest<Personal>.GetRequest(url);
            return result;

        }




        public static async Task<Personal> DeletePersonal(int id)
        {

            string url = string.Format("api/Personal/DeletePersonal?Id=" + id);
            Personal result = await ApiRequest<Personal>.GetRequest(url);
            return result;
        }
    }
}
