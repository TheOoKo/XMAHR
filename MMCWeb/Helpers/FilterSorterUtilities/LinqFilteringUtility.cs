using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MMCWeb.Helpers.FilterSorterUtilities
{
    public static class LinqFilteringUtility
    {
        public static IEnumerable<T> MultipleFilter<T>(this IEnumerable<T> data,
          List<FilterHelper> filterExpressions)
        {
            if ((filterExpressions == null) || (filterExpressions.Count <= 0))
            {
                return data;
            }

            IEnumerable<T> filteredquery = from item in data select item;

            for (int i = 0; i < filterExpressions.Count; i++ )
            {
                var index = i;

                Func<T, bool> expression = item =>
                    {
                        var filter = filterExpressions[index];
                        var itemValue = item.GetType()
                            .GetProperty(filter.Field)
                            .GetValue(item, null);

                        if (itemValue == null)
                        {
                            return false;
                        }
                        
                        var value = filter.Value;
                        switch (filter.Operator)
                        {
                            case "eq":
                                return itemValue.ToString().ToUpper() == value.ToUpper();
                            case "dt_eq":

                                string dt_format = "yyyy-MM-dd";
                                DateTime dt_filter = DateTime.Parse(value.ToString());
                                DateTime dt_org = DateTime.Parse(itemValue.ToString());
                                string original_dt = dt_org.ToString(dt_format);
                                string filter_dt = dt_filter.ToString(dt_format);

                                return original_dt.Equals(filter_dt);
                            case "startswith":
                                return itemValue.ToString().StartsWith(value);
                            case "contains":
                                //Change to small letter
                                return itemValue.ToString().ToUpper().Contains(value.ToUpper());
                            case "endswith":
                                return itemValue.ToString().EndsWith(value.ToUpper());
                        }

                        return true;
                    };

                filteredquery = filteredquery.Where(expression);
            }

            return filteredquery;
        }
    }
}