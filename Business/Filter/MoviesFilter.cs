using Business.FilterAndSort;
using Business.Sorting;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Enums.DBEnums;
using static Entities.Enums.ModelEnums;

namespace Business.Filter
{
    public class MoviesFilter : BaseFilter, IFilterAndSort<Movie>
    {
        public string? ID { get; set; }
        public int? imdbStar { get; set; }
        public int? userRating { get; set; }
        public string? Title { get; set; }
        public YearOptions? Year { get; set; }
        public MovieCategoryOptions? genre { get; set; }
        public IQueryable<Movie> Filter(IQueryable<Movie> list)
        {
            list = list.Where(m => m.IsDeleted == false);
            if (!Title.IsNullOrEmpty())
                list = list.Where(m => m.Title.Contains(Title));
            if (imdbStar.HasValue)
                list = list.Where(m => m.IMDBstar >= imdbStar);
            if (userRating.HasValue)
            {
                list = list.Where(m => m.Reviews
                      .Where(r => !r.IsDeleted)
                      .Average(r => (double)r.Star) >= userRating);
            }
            if (Year.HasValue)
            {
                switch (Year)
                {
                    default:

                        break;
                    case YearOptions.From2020:
                        list = list.Where(m => m.Year >= 2020);
                        break;
                    case YearOptions.From2010To2019:
                        list = list.Where(m => m.Year >= 2010 && m.Year <= 2019);
                        break;

                    case YearOptions.From2000To2009:
                        list = list.Where(m => m.Year >= 2000 && m.Year <= 2009);
                        break;

                    case YearOptions.From1990To1999:
                        list = list.Where(m => m.Year >= 1990 && m.Year <= 1999);
                        break;

                    case YearOptions.From1980To1989:
                        list = list.Where(m => m.Year >= 1980 && m.Year <= 1989);
                        break;

                    case YearOptions.From1970To1979:
                        list = list.Where(m => m.Year >= 1970 && m.Year <= 1979);
                        break;

                    case YearOptions.OlderThan1969:
                        list = list.Where(m => m.Year <= 1969);
                        break;

                }
            }
            if (!ID.IsNullOrEmpty())
                list = list.Where(m => m.Id == ID);
            if (genre.HasValue)
                list = list.Where(m => m.MovieCategories.Any(c => c.Category.MovieCategory == genre));
            return list;
        }

        public IQueryable<Movie> Sort(IQueryable<Movie> list)
        {
            switch (sortBy)
            {
                default: return list;
                case "imdbStar":
                    return sortAsc ? list.OrderBy(m => m.IMDBstar) : list.OrderByDescending(m => m.IMDBstar);
                case "year":
                    return sortAsc ? list.OrderBy(m => m.Year) : list.OrderByDescending(m => m.Year);
            }
        }
    }
}
