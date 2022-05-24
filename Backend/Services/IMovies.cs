using BookMyShow.core.Models;
using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Services
{
    public interface IMovies
    {
        public List<MovieDTO> GetMovies();
        public List<String> GetMovie(int id);
        public void DeleteMovie(int id);
        public Task<ActionResult<MovieDTO>> PostUser(Movie movie);
    }
}
