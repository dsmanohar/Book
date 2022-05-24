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

        public UserDTO GetUser(int id)
        {
            return _mapper.Map<UserDTO>(_context.Users.Find(id));
        }

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

        public UserDTO CheckUser(Login login)
        {
            var a = db.SingleOrDefault<User>("SELECT * FROM Users where Email=@0 and Password=@1 and isdeleted=0", login.Email, login.Password);
            return _mapper.Map<UserDTO>(a);
        }
    }
}
