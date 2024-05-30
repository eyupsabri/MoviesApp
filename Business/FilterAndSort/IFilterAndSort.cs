using Business.Filter;
using Business.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FilterAndSort
{
    public interface IFilterAndSort<T> : IFilterable<T>, ISorting<T> where T : class
    {
    }
}
