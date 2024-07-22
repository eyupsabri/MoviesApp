using AutoMapper;
using Business.Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAppUser.ActionFilter;
using MoviesAppUser.Models;

namespace MoviesAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(MyAuthActionFilter))]
    public class MovieReviewsController : ControllerBase
    {
        private IMovieReviewsService _movieReviewsService;
        private IUserService _userService;
        private readonly IMapper _mapper;


        public MovieReviewsController(IMovieReviewsService movieReviewsService, IUserService userService, IMapper mapper)
        {
            _movieReviewsService = movieReviewsService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddReview([FromBody] MovieReviewModel model)
        {
            if (HttpContext.Items["Email"] is string email)
            {
                var user = await _userService.GetUserByEmail(email);
                if (user != null)
                {
                    model.UserId = user.Id;
                    var mappedReview = _mapper.Map<MovieReview>(model);
                    var result = await _movieReviewsService.AddMovieReview(mappedReview);
                    return Ok();
                }
            }
            return BadRequest();

        }

    }
}
