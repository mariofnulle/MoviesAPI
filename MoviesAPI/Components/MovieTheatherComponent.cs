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
    public class MovieTheatherComponent : IMovieTheather
    {
        private readonly AppDbContext _context;

        public MovieTheatherComponent(AppDbContext context)
        {
            _context = context;
        }

        #region GetAllMovieTheathers

        public List<MovieTheather> GetAllMovieTheathers()
        {
            try
            {
                return _context.MovieTheathers.ToList();

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public List<MovieTheather> GetAllMovieTheathers(string movieName)
        {
            try
            {
                IEnumerable<MovieTheather> MovieTheathersList = _context.MovieTheathers;

                if (MovieTheathersList != null && !string.IsNullOrEmpty(movieName))
                {
                    MovieTheathersList = from theather in MovieTheathersList
                                         where theather.Sessions.Any(session =>
                                         session.Movie.Title.Contains(movieName))
                                         select theather;
                }

                return MovieTheathersList.ToList();

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region GetMovieTheatherById

        public MovieTheather GetMovieTheatherById(int id)
        {
            try
            {
                return _context.MovieTheathers.FirstOrDefault(MovieTheather => MovieTheather.Id == id);

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region AddMovieTheather

        public void AddMovieTheather(MovieTheather MovieTheather)
        {
            try
            {
                _context.MovieTheathers.Add(MovieTheather);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when adding a new Movie Theather.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region UpdateMovieTheather

        public void UpdateMovieTheather(MovieTheather MovieTheather)
        {
            try
            {
                _context.MovieTheathers.Update(MovieTheather);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when updating the Movie Theather.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region DeleteMovieTheather

        public Result DeleteMovieTheather(int id)
        {
            try
            {
                MovieTheather MovieTheather = GetMovieTheatherById(id);

                if (MovieTheather == null)
                    return Result.Fail("Movie theather doesn't exist or wasn't found.");

                _context.MovieTheathers.Remove(MovieTheather);
                _context.SaveChanges();

                return Result.Ok();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when removing the Movie Theather.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

    }
}
