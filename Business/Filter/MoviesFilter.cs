using Business.FilterAndSort;
using Business.Sorting;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public class MoviesFilter : BaseFilter, IFilterAndSort<Movie>
    {
        public double? IMDBstar { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public IQueryable<Movie> Filter(IQueryable<Movie> list)
        {
            if (!Title.IsNullOrEmpty())
                list = list.Where(m => m.Title.Contains(Title));
            if (IMDBstar.HasValue)
                list = list.Where(m => m.IMDBstar >= IMDBstar);
            if (Year.HasValue)
                list = list.Where(m => m.Year == Year);
            return list;
        }

        public IQueryable<Movie> Sort(IQueryable<Movie> list)
        {
            switch (sortBy)
            {
                default: return list;
                case "imdbStart":
                    return sortAsc ? list.OrderBy(m => m.IMDBstar) : list.OrderByDescending(m => m.IMDBstar);
                case "year":
                    return sortAsc ? list.OrderBy(m => m.Year) : list.OrderByDescending(m => m.Year);
            }
        }
    }
}
