using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public interface IFilterable<T> where T : class
    {
        public IQueryable<T> Filter(IQueryable<T> list);
    }
}
