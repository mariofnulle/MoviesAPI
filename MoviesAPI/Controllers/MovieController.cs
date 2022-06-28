using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> movies = new();
        public static int id = 1;

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetMovie()
        {
            return Ok(movies);
        }

        [HttpGet ("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = movies.FirstOrDefault(movie => movie.Id == id);

            if (movie != null)
                return Ok(movie);

            return NotFound();
        }

    }
}
