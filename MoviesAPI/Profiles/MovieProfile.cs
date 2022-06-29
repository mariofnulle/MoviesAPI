using AutoMapper;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Address>();
            CreateMap<UpdateMovieDto, Address>();
            CreateMap<Address, ReadMovieDto>();
        }
    }
}
