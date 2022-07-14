using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheatherController : ControllerBase
    {
        private readonly IMovieTheatherService _movieTheatherService;

        public MovieTheatherController(IMovieTheatherService movieTheatherService)
        {
            _movieTheatherService = movieTheatherService;
        }

        #region GetMovieTheather

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllMovieTheathers()
        {
            try
            {
                List<MovieTheather> movieTheathers = _movieTheatherService.GetAllMovieTheathers();

                if(movieTheathers.Count > 0)
                    return Ok(movieTheathers);

                return NotFound("There isn't any movie theathers registered");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllMovieTheathers(string movieName)
        {
            try
            {
                List<MovieTheather> movieTheathers = _movieTheatherService.GetAllMovieTheathers(movieName);

                if (movieTheathers.Count > 0)
                    return Ok(movieTheathers);

                return NotFound("There isn't any movie theathers registered within filter criteria");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetMovieTheatherById

        [HttpGet ("{id}")]
        public IActionResult GetMovieTheatherById(int id)
        {
            try
            {
                ReadMovieTheatherDto movieTheather = _movieTheatherService.GetMovieTheatherById(id);

                if (movieTheather != null)
                    return Ok(movieTheather);

                return NotFound(new { Message = "Informed movie theather doesn't exist or wasn't found." });
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region AddMovieTheather

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddMovieTheather([FromBody] CreateMovieTheatherDto newMovie)
        {
            try
            {
                ReadMovieTheatherDto movieTheather = _movieTheatherService.AddMovieTheather(newMovie);
                return CreatedAtAction(nameof(GetMovieTheatherById), new { movieTheather.Id }, movieTheather);
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

        #region UpdateMovieTheather

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieTheatherDto updateMovie)
        {
            try
            {
                Result result = _movieTheatherService.UpdateMovieTheather(id, updateMovie);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new {Message = "Movie theather successfully updated." });
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

        #region DeleteMovieTheather

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteMovieTheather(int id)
        {
            try
            {
                Result result = _movieTheatherService.DeleteMovieTheather(id);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new { Message = "Movie theather successfully deleted." });
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
