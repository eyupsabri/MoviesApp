using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IMovieReviewsRepository
    {
        public Task<bool> AddMovieReview(MovieReview review);
        public Task<bool> DeleteReview(int id);
    }
}
