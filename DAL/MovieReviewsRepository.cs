using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _db.MoviesReviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review != null)
            {
                review.IsDeleted = true;
                int i = await _db.SaveChangesAsync();
                return i > 0;
            }
            return review != null;
        }
    }
}
