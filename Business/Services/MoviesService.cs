﻿using Business.Filter;
using Business.FilterAndSort;
using DAL;
using Entities;
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

        public ICollection<Movie> GetMovies(MoviesFilter filter)
        {
            var movies = _moviesRepo.GetMovies().FilterAndSort(filter);

            return movies.ToList();
        }
    }
}
