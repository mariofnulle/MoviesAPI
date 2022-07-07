using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesComponents
{
    public class MovieTheatherService : IMovieTheatherService
    {
        private readonly IMapper _mapper;
        private readonly IMovieTheather _movieTheatherInterface;

        public MovieTheatherService(IMapper mapper, IMovieTheather movieTheatherInterface)
        {
            _mapper = mapper;
            _movieTheatherInterface = movieTheatherInterface;
        }

        #region GetAllMovieTheathers

        public List<MovieTheather> GetAllMovieTheathers()
        {
            try
            {
                return _movieTheatherInterface.GetAllMovieTheathers();
            }
            catch(Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        public List<MovieTheather> GetAllMovieTheathers(string movieName)
        {
            try
            {
                return _movieTheatherInterface.GetAllMovieTheathers(movieName);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region GetMovieTheatherById

        public ReadMovieTheatherDto GetMovieTheatherById(int id)
        {
            try
            {
                MovieTheather movie = _movieTheatherInterface.GetMovieTheatherById(id);

                if (movie != null)
                    return _mapper.Map<ReadMovieTheatherDto>(movie);

                return null;
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region AddMovieTheather

        public ReadMovieTheatherDto AddMovieTheather(CreateMovieTheatherDto newMovieTheather)
        {
            try
            {
                MovieTheather movieTheather = _mapper.Map<MovieTheather>(newMovieTheather);
                _movieTheatherInterface.AddMovieTheather(movieTheather);
                return _mapper.Map<ReadMovieTheatherDto>(movieTheather);
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

        #region UpdateMovieTheather

        public Result UpdateMovieTheather(int id, UpdateMovieTheatherDto updateMovieTheather)
        {
            try
            {
                ReadMovieTheatherDto movieTheatherDto = GetMovieTheatherById(id);

                if (movieTheatherDto == null)
                    return Result.Fail("Movie theather doesn't exist or wasn't found.");

                MovieTheather movieTheather = _mapper.Map<MovieTheather>(movieTheatherDto);

                _movieTheatherInterface.UpdateMovieTheather(_mapper.Map(updateMovieTheather, movieTheather));

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

        #region DeleteMovieTheather

        public Result DeleteMovieTheather(int id)
        {
            try
            {
                return _movieTheatherInterface.DeleteMovieTheather(id);
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
