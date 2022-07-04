using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IMovie
    {
        public IEnumerable<Movie> GetAllMovies();
        public IEnumerable<Movie> GetAllMovies(string title, string director, string gender, int? duration, Rate rate);
        public Movie GetMovieById(int id);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(int id);
    }
}
