using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow.core.Models;

namespace BookMyShow.Services
{
    public class Helper:IHelper
    {
        private readonly BookMyShowContext _context;
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        public Helper(BookMyShowContext context, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            db = new DataBaseService.Database().getDb();
        }

        /// <summary>
        /// get all the users 
        /// </summary>
        /// <returns>List of users</returns>
        public  List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();  
            var res =   _context.Users.ToList();
            foreach(var a in res)
            {
                users.Add(_mapper.Map<UserDTO>(a));
            }
            return users;
        }

        /// <summary>
        /// get information about specific user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>UserDto</returns>
        public UserDTO GetUser(int id)
        {
            return _mapper.Map<UserDTO>(_context.Users.Find(id));
        }

        /// <summary>
        /// add user to users table
        /// </summary>
        /// <param name="userdto">information about user</param>
        /// <returns>UserDto with generated id</returns>
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userdto)
        {

            var a = db.SingleOrDefault<User>("SELECT * FROM Users where Email=@0 and isdeleted = 0", userdto.Email);
            if (a != null)
            {
                return null;
            }
            var res = _mapper.Map<User>(userdto);
            res.CreatedOn = DateTime.Now;
            _context.Users.Add(res);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(res);
        }

        /// <summary>
        /// check user details for login
        /// </summary>
        /// <param name="login">info about user</param>
        /// <returns>UserDTO</returns>
        public UserDTO CheckUser(Login login)
        {
            var a = db.SingleOrDefault<User>("SELECT * FROM Users where Email=@0 and Password=@1 and isdeleted=0", login.Email, login.Password);
            return _mapper.Map<UserDTO>(a);
        }
    }
}
