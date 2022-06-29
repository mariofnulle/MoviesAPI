using AutoMapper;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTheatherProfile : Profile
    {
        public MovieTheatherProfile()
        {
            CreateMap<CreateAdressDto, Address>();
            CreateMap<UpdateMovieTheatherDto, Address>();
            CreateMap<Address, ReadMovieTheatherDto>();
        }
    }
}
