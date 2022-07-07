using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        #region GetSession

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllSessions()
        {
            try
            {
                List<Session> session = _sessionService.GetAllSessions();

                if(session.Count > 0)
                    return Ok(session);

                return NotFound("There isn't any sessions registered.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllSessions(int? theatherId, int? movieId)
        {
            try
            {
                List<Session> session = _sessionService.GetAllSessions(theatherId, movieId);

                if (session.Count > 0)
                    return Ok(session);

                return NotFound("There isn't any sessions registered.");
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
                ReadSessionDto session = _sessionService.GetSessionById(id);

                if (session != null)
                    return Ok(session);

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
        public IActionResult AddSession(CreateSessionDto sessionDto)
        {
            try
            {
                ReadSessionDto session = _sessionService.AddSession(sessionDto);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateSessionDto updateSession)
        {
            try
            {
                Result result = _sessionService.UpdateSession(id, updateSession);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

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
                Result result = _sessionService.DeleteSession(id);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

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
