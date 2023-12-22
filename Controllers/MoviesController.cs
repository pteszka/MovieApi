using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        
        // GET: api/Movies/TopRated?pageNumber=2
        [HttpGet("TopRated")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTopRatedMovies(int pageNumber)
        {
            var movies = await _movieRepository.GetTopRatedMovies(pageNumber);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movies/MostPopular?pageNumber=2
        [HttpGet("MostPopular")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMostPopularMovies(int pageNumber)
        {
            var movies = await _movieRepository.GetMostPopularMovies(pageNumber);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}