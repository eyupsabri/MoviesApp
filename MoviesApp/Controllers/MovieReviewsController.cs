using Business.Services;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAppUser.ActionFilter;

namespace MoviesAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(MyAuthActionFilter))]
    public class MovieReviewsController : ControllerBase
    {
        private IMovieReviewsService _movieReviewsService;
        private IUserService _userService;

        public MovieReviewsController(IMovieReviewsService movieReviewsService, IUserService userService)
        {
            _movieReviewsService = movieReviewsService;
            _userService = userService;
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
                    var result = await _movieReviewsService.AddMovieReview(model);
                    return Ok();
                }
            }
            return BadRequest();

        }

    }
}
