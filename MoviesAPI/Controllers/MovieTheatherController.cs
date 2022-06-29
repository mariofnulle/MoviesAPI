using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Components;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.MovieTheather;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheatherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieTheather _movieTheatherInterface;

        public MovieTheatherController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _movieTheatherInterface = new MovieTheatherComponent(context);
        }

        #region GetMovieTheather

        [HttpGet]
        public IActionResult GetAllMovieTheathers()
        {
            try
            {
                return Ok(_movieTheatherInterface.GetAllMovieTheathers());
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
                MovieTheather movieTheather = _movieTheatherInterface.GetMovieTheatherById(id);

                if (movieTheather != null)
                {
                    ReadMovieTheatherDto readMovie = _mapper.Map<ReadMovieTheatherDto>(movieTheather);
                    readMovie.LookupDate = DateTime.Now;
                    return Ok(readMovie);
                }

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
        public IActionResult AddMovieTheather([FromBody] CreateMovieTheatherDto newMovie)
        {
            try
            {
                MovieTheather movieTheather = _mapper.Map<MovieTheather>(newMovie);
                _movieTheatherInterface.AddMovieTheather(movieTheather);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieTheatherDto updateMovie)
        {
            try
            {
                MovieTheather movieTheather = _movieTheatherInterface.GetMovieTheatherById(id);
                _mapper.Map(updateMovie, movieTheather);
                _movieTheatherInterface.UpdateMovieTheather(movieTheather);
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
        public IActionResult DeleteMovieTheather(int id)
        {
            try
            {
                _movieTheatherInterface.DeleteMovieTheather(id);
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
