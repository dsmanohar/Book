using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Services
{
    public interface IMovies
    {
        public List<MovieDTO> GetMovies();
        public List<String> GetMovie(int id);

    }
}
