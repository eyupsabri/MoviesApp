using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _db;
        public MoviesRepository(AppDbContext context)
        {
            _db = context;
        }
        public IQueryable<Movie> GetMovies()
        {
            return _db.Movies;
        }
    }
}
