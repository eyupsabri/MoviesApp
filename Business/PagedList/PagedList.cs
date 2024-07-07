using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PagedList
{
    public class PagedList<T> where T : class
    {
        
        public int PageIndex { get; private set; }
        public int PageCount { get; private set; }
        public List<T> FinalList { get; private set; }
        public PagedList(int pageIndex) { 
            PageIndex = pageIndex;
            FinalList = new List<T>();
        }

        public void ToPagedList(IQueryable<T> list)
        {
            var numberOfElements = list.Count();
            PageCount = numberOfElements / 12 + 1;
            if(numberOfElements % 12 == 0)
            {
                PageCount = PageCount - 1;
            }
            FinalList = list.Skip(PageIndex * 12).Take(12).ToList();
            
        }
    }
}
