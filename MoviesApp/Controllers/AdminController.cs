using AutoMapper;
using Business.Services;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesAppUser.ActionFilter;
using System.Linq;
using System.Net;

namespace MoviesAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AdminController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private ICategoriesService _categoriesService;
        private IMoviesService _moviesService;
        private IUserService _userService;

        public AdminController(IMapper autoMapper, ICategoriesService catService, IMoviesService movieService, IUserService userService)
        {
            _autoMapper = autoMapper;
            _categoriesService = catService;
            _moviesService = movieService;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Deneme()
        {
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(MyAuthActionFilter))]
        public async Task<IActionResult> AddMovie(MovieAddDTO movieToAdd)
        {
            //var movie = _autoMapper.Map<Movie>(movieToAdd);
            if (HttpContext.Items["Email"] is string email)
            {
                var user = await _userService.GetUserByEmail(email);
                if (user == null || !user.IsAdmin) return BadRequest();
            }

            List<MovieCategory> movieCategories = new List<MovieCategory>();
            foreach (var category in movieToAdd.Genre)
            {
                var cat = await _categoriesService.GetCategory(category);
                MovieCategory movieCategory = new MovieCategory() { CategoryId = cat.Id, MovieId = movieToAdd.Id };
                movieCategories.Add(movieCategory);
            }

            var movie = _autoMapper.Map<Movie>(movieToAdd, opt => opt.Items["MovieCategories"] = movieCategories);

            string message = "";
            bool response;
            try
            {
                response = await _moviesService.AddMovie(movie);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                response = false;
            }


            if (response)
                return Ok();
            else if (message.Contains("because another instance with the same key value"))
                return BadRequest("Movie already in database");
            else return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [ServiceFilter(typeof(MyAuthActionFilter))]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            //var movie = _autoMapper.Map<Movie>(movieToAdd);
            if (HttpContext.Items["Email"] is string email)
            {
                var user = await _userService.GetUserByEmail(email);
                if (user == null || !user.IsAdmin) return BadRequest();
            }
            var response = await _moviesService.DeleteMovie(id);
            if (response) return Ok();
            return BadRequest();
        }
    }
}
