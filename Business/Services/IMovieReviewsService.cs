using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IMovieReviewsService
    {
        public Task<bool> AddMovieReview(MovieReviewModel review);
    }
}
