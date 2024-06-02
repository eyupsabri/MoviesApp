using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IMoviesRepository
    {
        public IQueryable<Movie> GetMovies();
        public Task<Movie> GetMovieById(string id);
    }
}
