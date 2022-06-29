using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Components
{
    public class MovieComponent : IMovie
    {
        private readonly MovieContext _context;

        public MovieComponent(MovieContext context)
        {
            _context = context;
        }

        #region GetAllMovies

        public IEnumerable<Movie> GetAllMovies()
        {
            try
            {
                return _context.Movies;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public IEnumerable<Movie> GetAllMovies(string Title, string Director, string Gender, int? Duration)
        {
            try
            {
                IEnumerable<Movie> moviesList = _context.Movies;

                if (!string.IsNullOrEmpty(Title))
                    moviesList = moviesList.Where(movie => movie.Title.Contains(Title));

                if (!string.IsNullOrEmpty(Director))
                    moviesList = moviesList.Where(movie => movie.Director.Contains(Director));

                if (!string.IsNullOrEmpty(Gender))
                    moviesList = moviesList.Where(movie => movie.Gender.Contains(Gender));

                if (Duration != null && Duration > 0)
                    moviesList = moviesList.Where(movie => movie.Duration == Duration);

                return moviesList;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region GetMovieById

        public Movie GetMovieById(int id)
        {
            try
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id);

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region AddMovie

        public void AddMovie(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when adding a new movie.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region UpdateMovie

        public void UpdateMovie(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when updating the movie.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region DeleteMovie

        public void DeleteMovie(int id)
        {
            try
            {
                Movie movie = GetMovieById(id);

                if (movie == null)
                    throw new DbUpdateException();

                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when removing the movie.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

    }
}
