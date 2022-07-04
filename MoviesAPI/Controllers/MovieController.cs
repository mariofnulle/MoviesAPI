using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Components;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovie _movieInterface;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _movieInterface = new MovieComponent(context);
        }

        #region GetMovie

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllMovies()
        {
            try
            {
                return Ok(_movieInterface.GetAllMovies());
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
                return Ok(_movieInterface.GetAllMovies(title, director, gender, duration, rate));
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
                Movie movie = _movieInterface.GetMovieById(id);

                if (movie != null)
                {
                    ReadMovieDto readMovie = _mapper.Map<ReadMovieDto>(movie);
                    return Ok(readMovie);
                }

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
        public IActionResult AddMovie([FromBody] CreateMovieDto newMovie)
        {
            try
            {
                Movie movie = _mapper.Map<Movie>(newMovie);
                _movieInterface.AddMovie(movie);
                return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovie)
        {
            try
            {
                Movie movie = _movieInterface.GetMovieById(id);
                _mapper.Map(updateMovie, movie);
                _movieInterface.UpdateMovie(movie);
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
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                _movieInterface.DeleteMovie(id);
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
