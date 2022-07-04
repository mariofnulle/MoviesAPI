using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Components;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISession _sessionInterface;
        public SessionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _sessionInterface = new SessionComponent(context);
        }

        #region GetSession

        [HttpGet]
        public IActionResult GetAllSessions()
        {
            try
            {
                return Ok(_sessionInterface.GetAllSession());
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetSessionById

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            try
            {
                Session session = _sessionInterface.GetSessionById(id);

                if (session != null)
                {
                    ReadSessionDto readMovie = _mapper.Map<ReadSessionDto>(session);
                    return Ok(readMovie);
                }

                return NotFound(new { Message = "Informed Session doesn't exist or wasn't found." });
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region AddSession

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto SessionDto)
        {
            try
            {
                Session session = _mapper.Map<Session>(SessionDto);
                _sessionInterface.AddSession(session);
                return CreatedAtAction(nameof(GetSessionById), new { session.Id }, session);
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

        #region UpdateSession

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateSessionDto updateMovie)
        {
            try
            {
                Session session = _sessionInterface.GetSessionById(id);
                _mapper.Map(updateMovie, session);
                _sessionInterface.UpdateSession(session);
                return Ok(new { Message = "Session successfully updated." });
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

        #region DeleteSession

        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            try
            {
                _sessionInterface.DeleteSession(id);
                return Ok(new { Message = "Session successfully deleted." });
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
