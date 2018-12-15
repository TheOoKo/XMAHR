using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
   public class SectionApiRequestHelper
    {
        public static async Task<List<Section>> GetSectionName()
        {
            string url = string.Format("/api/Personal/GetSection");
            var data = await ApiRequest<List<Section>>.GetRequest(url);
            return data;
        }

    }
}
