using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using PetaPoco.Providers;
using BookMyShow.core.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly ITheaters _theater;
        public TheatersController(BookMyShowContext context, ITheaters theater)
        {
            _context = context;
            _theater = theater;
            
        }

        [HttpGet("{id}")]
        public ActionResult GetTheaters(int id)
        {
            var res = _theater.GetTheaters(id);
            return Ok(res);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteTheater(int id)
        {
            _theater.DeleteTheater(id);
            return Ok(null);
        }

        [HttpPost]
        public async Task<ActionResult<TheaterDTO>> PostUser(Theater theater)
        {
            var res = await _theater.PostUser(theater);
            return res;
        }
    }
}
