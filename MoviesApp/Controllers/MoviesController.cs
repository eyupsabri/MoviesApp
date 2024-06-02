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
    public class MoviesController : ControllerBase
    {
        private IMoviesService _moviesService;
        private readonly IMapper _autoMapper;

        public MoviesController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _autoMapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MovieDTO>))]
        public async Task<IActionResult> GetMovies([FromQuery] MoviesFilter filter)
        {
            ICollection<Movie> movies = _moviesService.GetMovies(filter).ToList();
            var mapped = movies.Select(m => _autoMapper.Map<MovieDTO>(m));

            return Ok(mapped);
        }

        [HttpGet]
        [Route("{movieID}")]
        public async Task<IActionResult> GetMovie(string movieID)
        {
            var movie = await _moviesService.GetMovieById(movieID);
            var mapped = _autoMapper.Map<MovieDetailedDTO>(movie);
            return Ok(mapped);

        }
    }
}
