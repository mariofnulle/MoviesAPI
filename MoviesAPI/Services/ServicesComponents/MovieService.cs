using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesComponents
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovie _movieInterface;

        public MovieService(IMapper mapper, IMovie movieInterface)
        {
            _mapper = mapper;
            _movieInterface = movieInterface;
        }

        #region GetAllMovies

        public List<Movie> GetAllMovies()
        {
            try
            {
                return _movieInterface.GetAllMovies();
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        public List<Movie> GetAllMovies(string title, string director, string gender, int? duration, Rate rate)
        {
            try
            {
                return _movieInterface.GetAllMovies(title, director, gender, duration, rate);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region GetMovieById

        public ReadMovieDto GetMovieById(int id)
        {
            try
            {
                Movie movie = _movieInterface.GetMovieById(id);

                if (movie != null)
                    return _mapper.Map<ReadMovieDto>(movie);

                return null;
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region AddMovie

        public ReadMovieDto AddMovie(CreateMovieDto newMovie)
        {
            try
            {
                Movie movie = _mapper.Map<Movie>(newMovie);
                _movieInterface.AddMovie(movie);
                return _mapper.Map<ReadMovieDto>(movie);
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region UpdateMovie

        public Result UpdateMovie(int id, UpdateMovieDto updateMovie)
        {
            try
            {
                ReadMovieDto movieDto = GetMovieById(id);

                if (movieDto == null)
                    return Result.Fail("Movie doesn't exist or wasn't found.");

                Movie movie = _mapper.Map<Movie>(movieDto);

                _movieInterface.UpdateMovie(_mapper.Map(updateMovie, movie));

                return Result.Ok();
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region DeleteMovie

        public Result DeleteMovie(int id)
        {
            try
            {
                return _movieInterface.DeleteMovie(id);
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion
    }
}
