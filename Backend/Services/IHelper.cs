using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Services
{
    public interface IHelper
    {
        public List<UserDTO> GetUsers();
        public UserDTO GetUser(int id);
        public Task<ActionResult<UserDTO>> PostUser(UserDTO userdto);
        public UserDTO CheckUser(Login login);

    }
}
