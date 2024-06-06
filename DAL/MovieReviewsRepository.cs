using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MovieReviewsRepository : IMovieReviewsRepository
    {
        private readonly AppDbContext _db;
        public MovieReviewsRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }
        public async Task<bool> AddMovieReview(MovieReview review)
        {
            _db.MoviesReviews.Add(review);
            int i = await _db.SaveChangesAsync();
            return i > 0;
        }
    }
}
