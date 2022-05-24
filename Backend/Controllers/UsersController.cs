using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetaPoco;
using BookMyShow.Models;
using PetaPoco.Providers;
using BookMyShow.Services;
using AutoMapper;
using BookMyShow.core.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IHelper _helper;
        private readonly AutoMapper.IMapper _mapper;
        public UsersController(BookMyShowContext context, IHelper helper, AutoMapper.IMapper mapper)
        {
            _context = context;
            _helper = helper;
            _mapper = mapper;

         }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetUsers()
        {
           return Ok(_helper.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return Ok(_helper.GetUser(id));
            
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userdto)
        {

            var res = await _helper.PostUser(userdto);
            return res;           
        }

        [HttpPost]
        public ActionResult<UserDTO> CheckUser(Login login)
        {
           return Ok(_helper.CheckUser(login)); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
