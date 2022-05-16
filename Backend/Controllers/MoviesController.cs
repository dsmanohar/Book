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
        private readonly IDatabase db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
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
    }
}
