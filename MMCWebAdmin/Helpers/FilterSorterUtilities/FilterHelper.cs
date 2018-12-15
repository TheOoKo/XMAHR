using System.Collections.Generic;
using System.Web;

namespace MMCWeb.Helpers.FilterSorterUtilities
{
    public class FilterCollection
    {
        public List<FilterHelper> Filters { get; private set; }
        private FilterCollection()
        {
            Filters = new List<FilterHelper>();
        }

        public static FilterCollection BuildEmptyCollection()
        {
            return new FilterCollection();
        }

        public static FilterCollection BuildCollection(HttpRequestBase request)
        {
            var collection = BuildEmptyCollection();

            var idex = 0;
            while (true)
            {
                var filter = new FilterHelper()
                {
                    Field = request.Params["filter[filters][" + idex + "][field]"],
                    Operator = request.Params["filter[filters][" + idex + "][operator]"],
                    Value = request.Params["filter[filters][" + idex + "][value]"]
                };

                if (filter.Field == null) { break; }
                collection.Filters.Add(filter);
                idex++;
            }

            return collection;
        }
    }

    public class FilterHelper
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}