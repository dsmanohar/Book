﻿using BookMyShow.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow.core.Models;
using BookMyShow.Services.DataBaseService;
using Microsoft.Data.SqlClient;

namespace BookMyShow.Services
{
    public class Movies: IMovies
    {
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        private readonly BookMyShowContext _context;
        public Movies(AutoMapper.IMapper mapper, BookMyShowContext context)
        {
            _mapper = mapper;
            _context = context;
            db = new DataBaseService.Database().getDb();
        }
        public  List<MovieDTO> GetMovies()
        {
            
            List<MovieDTO> result = new List<MovieDTO>();
            foreach (var a in db.Query<Movie>("SELECT * FROM Movies where isdeleted=0"))
            {
                result.Add(_mapper.Map<MovieDTO>(a));
            }
            return result;
        }
        public List<String> GetMovie(int id)
        {
            db.EnableAutoSelect = false;
            var a = db.Fetch<string>(@"EXEC getmovie 
                                @@id = @0", id);
            return a;
        }
        public void DeleteMovie(int id)
        {
            db.Update<Movie>("SET isdeleted = 1  WHERE id = @0", id);
            return;

        }
        public async Task<ActionResult<MovieDTO>> PostUser(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return _mapper.Map<MovieDTO>(movie);
        }
    }
}
