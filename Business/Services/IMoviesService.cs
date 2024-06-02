using Business.Filter;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IMoviesService
    {
        public ICollection<Movie> GetMovies(MoviesFilter filter);
        public Task<Movie> GetMovieById(string id);
    }
}
