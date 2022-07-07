using FluentResults;
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
        private readonly AppDbContext _context;

        public MovieComponent(AppDbContext context)
        {
            _context = context;
        }

        #region GetAllMovies

        public List<Movie> GetAllMovies()
        {
            try
            {
                return _context.Movies.ToList();

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public List<Movie> GetAllMovies(string title, string director, string gender, int? duration, Rate rate)
        {
            try
            {
                IEnumerable<Movie> moviesList = _context.Movies;

                if (!string.IsNullOrEmpty(title))
                    moviesList = moviesList.Where(movie => movie.Title.Contains(title));

                if (!string.IsNullOrEmpty(director))
                    moviesList = moviesList.Where(movie => movie.Director.Contains(director));

                if (!string.IsNullOrEmpty(gender))
                    moviesList = moviesList.Where(movie => movie.Gender.Contains(gender));

                if (duration != null && duration > 0)
                    moviesList = moviesList.Where(movie => movie.Duration == duration);

                if (rate != Rate.None)
                    moviesList = moviesList.Where(movie => movie.MovieRate == rate);

                return moviesList.ToList();

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

        public Result DeleteMovie(int id)
        {
            try
            {
                Movie movie = GetMovieById(id);

                if (movie == null)
                    return Result.Fail("Movie doesn't exist or wasn't found.");

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return Result.Ok();
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
