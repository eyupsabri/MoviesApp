using AutoMapper;
using Business.Filter;
using Business.Services;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IMoviesService _moviesService;
        private readonly IMapper _autoMapper;

        public HomeController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _autoMapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Movie>))]
        public async Task<IActionResult> GetMovies([FromQuery] MoviesFilter filter)
        {
            ICollection<Movie> movies = _moviesService.GetMovies(filter).ToList();
            var mapped = movies.Select(m => _autoMapper.Map<MovieDTO>(m));

            return Ok(mapped);
        }
    }
}
