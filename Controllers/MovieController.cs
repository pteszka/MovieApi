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
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMovieRepository _movieRepository;

        public MovieController(DataContext context, IMovieRepository movieRepository)
        {
            _context = context;
            _movieRepository = movieRepository;
        }

        // GET: api/Movie/5
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
        
        // GET: api/Movie?pageNumber=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetTopRatedMovies(int pageNumber)
        {
            var movies = await _movieRepository.GetTopRatedMovies(pageNumber);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}