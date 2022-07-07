using FluentResults;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesInterfaces
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public List<Movie> GetAllMovies(string title, string director, string gender, int? duration, Rate rate);
        public ReadMovieDto GetMovieById(int id);
        public ReadMovieDto AddMovie(CreateMovieDto newMovie);
        public Result UpdateMovie(int id, UpdateMovieDto updateMovie);
        public Result DeleteMovie(int id);
    }
}
