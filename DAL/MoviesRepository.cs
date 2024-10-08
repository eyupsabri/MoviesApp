﻿using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);


            var result = await SaveChanges();


            return result;
        }

        public async Task<bool> DeleteMovie(string id)
        {
            var movie = await GetMovieById(id);
            movie.IsDeleted = true;

            foreach (var r in movie.Reviews)
            {
                r.IsDeleted = true;
            }
            var result = await SaveChanges();
            return result;
        }

        public async Task<Movie> GetMovieById(string id)
        {
            return await _db.Movies.FirstOrDefaultAsync(Movie => Movie.Id == id);
        }

        public IQueryable<Movie> GetMovies()
        {
            return _db.Movies;
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }
    }
}
