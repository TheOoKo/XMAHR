using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public class DivisionApiRequestHelper
    {

        public static async Task<List<Division>> GetDivisionName()
        {
            string url = string.Format("/api/Personal/GetDivision");
            var data = await ApiRequest<List<Division>>.GetRequest(url);
            return data;
        }
    }
}
