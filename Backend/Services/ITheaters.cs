using BookMyShow.Models;
using System.Web.Mvc;

namespace BookMyShow.Services
{
    public interface ITheaters
    {
        public List<TheaterDTO> GetTheaters(int id);
    }
}
