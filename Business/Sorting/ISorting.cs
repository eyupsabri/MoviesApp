using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sorting
{
    public interface ISorting<T> where T : class
    {
        public IQueryable<T> Sort(IQueryable<T> list);
    }
}
