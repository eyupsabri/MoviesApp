using AutoMapper;
using DAL;
using Entities;
using Entities.Models;
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
        private readonly IMapper _mapper;
        public MovieReviewsService(IMovieReviewsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> AddMovieReview(MovieReviewModel review)
        {
            var mappedReview = _mapper.Map<MovieReview>(review);
            var result = await _repo.AddMovieReview(mappedReview);
            return result;
        }
    }
}
