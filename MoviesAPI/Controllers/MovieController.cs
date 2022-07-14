using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        #region GetMovie

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllMovies()
        {
            try
            {
                List<Movie> movies = _movieService.GetAllMovies();

                if (movies.Count > 0)
                    return Ok(movies);

                return NotFound("There isn't any movies registered.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllMovies([FromQuery] string title, [FromQuery] string director,
                                          [FromQuery] string gender, [FromQuery] int? duration, [FromQuery] Rate rate = Rate.None)
        {
            try
            {
                List<Movie> movies = _movieService.GetAllMovies(title, director, gender, duration, rate);

                if (movies.Count > 0)
                    return Ok(movies);

                return NotFound("There isn't any movies registered within the filter criteria.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetMovieById

        [HttpGet ("{id}")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                ReadMovieDto readMovie = _movieService.GetMovieById(id);

                if (readMovie != null)
                    return Ok(readMovie);

                return NotFound(new { Message = "Informed movie doesn't exist or wasn't found." });
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region AddMovie

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddMovie([FromBody] CreateMovieDto newMovie)
        {
            try
            {
                ReadMovieDto readDto = _movieService.AddMovie(newMovie);
                return CreatedAtAction(nameof(GetMovieById), new { readDto.Id }, readDto);
            }
            catch (DbUpdateException message)
            {
                return BadRequest(message.Message);
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region UpdateMovie

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovie)
        {
            try
            {
                Result result = _movieService.UpdateMovie(id, updateMovie);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new {Message = "Movie successfully updated." });
            }
            catch (DbUpdateException message)
            {
                return BadRequest(message.Message);
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region DeleteMovie

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                Result result = _movieService.DeleteMovie(id);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new { Message = "Movie successfully deleted." });
            }
            catch (DbUpdateException message)
            {
                return BadRequest(message.Message);
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

    }
}
