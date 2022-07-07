using FluentResults;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IMovieTheather
    {
        public List<MovieTheather> GetAllMovieTheathers();
        public List<MovieTheather> GetAllMovieTheathers(string movieName);
        public MovieTheather GetMovieTheatherById(int id);
        public void AddMovieTheather(MovieTheather movie);
        public void UpdateMovieTheather(MovieTheather movie);
        public Result DeleteMovieTheather(int id);
    }
}
