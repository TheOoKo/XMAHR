
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public class PersonalDetailApiRequestHelper
    {
        public static async Task<Personal> UpsertPersonal(Personal personal)
        {


            string url =string.Format("api/PersonalDetail/UpsertPersonal");
            Personal result = await ApiRequest<Personal>.PostRequest(url, personal);




            return result;
        }
    }
}
