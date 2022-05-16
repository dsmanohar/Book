using AutoMapper;
using BookMyShow.Models;

namespace BookMyShow.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Theater,TheaterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
