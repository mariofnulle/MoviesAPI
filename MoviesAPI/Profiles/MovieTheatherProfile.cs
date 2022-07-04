using AutoMapper;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Profiles
{
    public class MovieTheatherProfile : Profile
    {
        public MovieTheatherProfile()
        {
            CreateMap<CreateMovieTheatherDto, MovieTheather>();
            CreateMap<UpdateMovieTheatherDto, MovieTheather>();
            CreateMap<MovieTheather, ReadMovieTheatherDto>();
        }
    }
}
