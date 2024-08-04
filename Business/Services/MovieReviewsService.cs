using AutoMapper;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MovieReviewsService : IMovieReviewsService
    {
        private readonly IMovieReviewsRepository _repo;
        //private readonly IMapper _mapper;
        public MovieReviewsService(IMovieReviewsRepository repo)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        public async Task<bool> AddMovieReview(MovieReview review)
        {
            // var mappedReview = _mapper.Map<MovieReview>(review);
            var result = await _repo.AddMovieReview(review);
            return result;
        }

        public async Task<bool> DeleteMovieReview(int id)
        {
            var result = await _repo.DeleteReview(id);
            return result;
        }
    }
}
