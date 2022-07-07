using FluentResults;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesInterfaces
{
    public interface IMovieTheatherService
    {
        public List<MovieTheather> GetAllMovieTheathers();
        public List<MovieTheather> GetAllMovieTheathers(string movieName);
        public ReadMovieTheatherDto GetMovieTheatherById(int id);
        public ReadMovieTheatherDto AddMovieTheather(CreateMovieTheatherDto newMovie);
        public Result UpdateMovieTheather(int id, UpdateMovieTheatherDto updateMovie);
        public Result DeleteMovieTheather(int id);
    }
}
