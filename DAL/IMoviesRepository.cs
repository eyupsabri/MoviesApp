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
        public Task<bool> AddMovie(Movie movie);
        public Task<bool> DeleteMovie(string id);

        public Task<bool> SaveChanges();
    }
}
