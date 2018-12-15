using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
   

    public class PagedListServer<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string prevLink { get; set; }
        public string nextLink { get; set; }
        public IEnumerable<T> Results { get; set; }
        public PagedListServer() { }
        public PagedListServer(IQueryable<T> objs, int pagesize, int page)
        {
            Results = objs.Skip(pagesize * (page - 1)).Take(pagesize).ToList();
            TotalCount = objs.Count();
            TotalPages = (int)Math.Ceiling((double)TotalCount / pagesize); 
        }
    }
    public class PagedListClient<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public string prevLink { get; set; }
        public string nextLink { get; set; }
        public IPagedList<T> Results { get; set; }
        public PagedListClient() { }
        public PagedListClient(IEnumerable<T> objs,int page, int pagesize, int totalcount)
        {
            Results = new StaticPagedList<T>(objs,page,pagesize,totalcount);
            TotalCount = totalcount;
            TotalPages = (int)Math.Ceiling((double)TotalCount / pagesize);
        }
    }

    public class PageCountInfo
    {
        public int TotalPageCount { get; set; }
        public int TotalRecordCount { get; set; }
        public PageCountInfo(int totalrecordcount, int pagesize)

        {
            TotalRecordCount = totalrecordcount;
            var mod = TotalRecordCount % pagesize;
            TotalPageCount = (TotalRecordCount / pagesize) + (mod == 0 ? 0 : 1);

        }
        public PageCountInfo() { }

    }
}

