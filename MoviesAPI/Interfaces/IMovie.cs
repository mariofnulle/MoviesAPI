using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IMovie
    {
        public IEnumerable<Movie> GetAllMovies();
        public IEnumerable<Movie> GetAllMovies(string Title, string Director, string Gender, int? Duration);
        public Movie GetMovieById(int id);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public void DeleteMovie(int id);
    }
}
