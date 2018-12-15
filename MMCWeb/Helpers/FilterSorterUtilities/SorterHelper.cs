using System;
using System.Collections.Generic;
using System.Web;

namespace MMCWeb.Helpers.FilterSorterUtilities
{
    public class SorterCollection
    {
        public List<SorterHelper> Sorters { get; private set; }
        private SorterCollection()
        {
            Sorters = new List<SorterHelper>();
        }

        public static SorterCollection BuildEmptyCollection()
        {
            return new SorterCollection();
        }

        public static SorterCollection BuildCollection(HttpRequestBase request)
        {
            var collection = BuildEmptyCollection();

            var idex = 0;
            while(true)
            {
                var sorter = new SorterHelper()
                {
                    Field = request.Params["sort[" + idex + "][field]"],
                    Direction = request.Params["sort[" + idex + "][dir]"] 
                };

                if (sorter.Field == null) { break; }
                collection.Sorters.Add(sorter);
                idex++;
            }

            return collection;
        }
    }

    public class SorterHelper
    {
        public string Field { get; set; }
        public string Direction { get; set; }
    }
}