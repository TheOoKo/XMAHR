using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public class EduHistoryApiRequestHelper
    {

        //Use PersonalID
        public static async Task<EduHistory> GetEduHistory(int id)
        {
            string url = string.Format("api/EducationHistory/GetEduHistory?Id=" + id);
            EduHistory result = await ApiRequest<EduHistory>.GetRequest(url);
            return result;
        }

        // Use EduHistoryID
        public static async Task<EduHistory> GetEduHistoryId(int id)
        {
            string url = string.Format("api/EducationHistory/GetEduHistoryId?Id=" + id);
            EduHistory result = await ApiRequest<EduHistory>.GetRequest(url);
            return result;
        }

        public static async Task<EduHistory> UpsertEduHistory(EduHistory education)
        {
            //string url = string.Format("api/EducationHistory/UpsertEducation");
            var url = "api/EducationHistory/UpsertEducation";
            EduHistory result = await ApiRequest<EduHistory>.PostRequest(url,education);
            return result;
        }

    }
}
