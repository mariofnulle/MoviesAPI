using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IMovieTheather
    {
        public IEnumerable<MovieTheather> GetAllMovieTheathers();
        public IEnumerable<MovieTheather> GetAllMovieTheathers(string movieName);
        public MovieTheather GetMovieTheatherById(int id);
        public void AddMovieTheather(MovieTheather movie);
        public void UpdateMovieTheather(MovieTheather movie);
        public void DeleteMovieTheather(int id);
    }
}
