using BookMyShow.Models;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow.core.Models;

namespace BookMyShow.Services
{
    public class Theaters: ITheaters
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IDatabase db;
        private readonly BookMyShowContext _context;
        public Theaters(AutoMapper.IMapper mapper, BookMyShowContext context)
        {
            _mapper = mapper;
            _context = context;
            db = new DataBaseService.Database().getDb();
        }

        /// <summary>
        /// get all the theaters for a specific movie
        /// </summary>
        /// <param name="id">MovieId</param>
        /// <returns>list of theaterDTO</returns>
        public List<TheaterDTO> GetTheaters(int id)
        {
            
            var a = db.Query<Theater>("select distinct t.Id,t.Name from shows as s inner join Theaters as t on s.theaterID = T.Id where movieID = @0 and s.isdeleted=0 and  t.isdeleted=0", id);
            List<TheaterDTO> theaters = new List<TheaterDTO>();
            foreach(var b in a)
            {
                theaters.Add(_mapper.Map<TheaterDTO>(b));
            }
            return theaters;
        }

        /// <summary>
        /// delete theater from theaters table
        /// </summary>
        /// <param name="id">theater id</param>
        public void DeleteTheater(int id)
        {
            db.Update<Theater>("SET isdeleted = 1  WHERE id = @0",id);
            return;
        }

        /// <summary>
        /// add theater to theaters table
        /// </summary>
        /// <param name="theater">Theater data</param>
        /// <returns>TheaterDTO</returns>
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<TheaterDTO>> PostUser(Theater theater)
        {           
            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();
            return _mapper.Map<TheaterDTO>(theater);
        }
    }
}
