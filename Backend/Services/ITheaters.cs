using BookMyShow.core.Models;
using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace BookMyShow.Services
{
    public interface ITheaters
    {
        public List<TheaterDTO> GetTheaters(int id);

        public void DeleteTheater(int id);
        public Task<ActionResult<TheaterDTO>> PostUser(Theater theater);
    }
}
