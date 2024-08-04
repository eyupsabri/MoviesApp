using Business.Filter;
using Business.FilterAndSort;
using DAL;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _moviesRepo;

        public MoviesService(IMoviesRepository moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }



        public IQueryable<Movie> GetMovies(MoviesFilter filter)
        {
            var movies = _moviesRepo.GetMovies().FilterAndSort(filter);

            return movies;
        }

        public async Task<Movie> GetMovieById(string id)
        {
            var movie = await _moviesRepo.GetMovieById(id);
            movie.Reviews = movie.Reviews.Where(r => !r.IsDeleted).ToList();
            return movie;
        }

        public async Task<bool> AddMovie(Movie movie)
        {
            var result = await _moviesRepo.AddMovie(movie);
            return result;
        }

        public async Task<bool> DeleteMovie(string id)
        {
            var result = await _moviesRepo.DeleteMovie(id);

            return result;

        }


    }
}
