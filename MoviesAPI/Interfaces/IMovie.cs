using FluentResults;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IMovie
    {
        public List<Movie> GetAllMovies();
        public List<Movie> GetAllMovies(string title, string director, string gender, int? duration, Rate rate);
        public Movie GetMovieById(int id);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public Result DeleteMovie(int id);
    }
}
