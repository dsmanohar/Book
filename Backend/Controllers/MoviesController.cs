using BookMyShow.core.Models;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IMovies _movies;
        public MoviesController(BookMyShowContext context,IMovies movies)
        {
            _context = context;
            _movies = movies;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var res = _movies.GetMovies();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var res = _movies.GetMovie(id);
            return Ok(res); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movies.DeleteMovie(id);
            return Ok(null);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostUser(Movie movie)
        {
            var res = await _movies.PostUser(movie);
            return res;
        }
    }
}
