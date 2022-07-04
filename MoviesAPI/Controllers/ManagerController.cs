using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Components;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IManager _managerInterface;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _managerInterface = new ManagerComponent(context);
        }

        #region GetManager

        [HttpGet]
        public IActionResult GetAllManagers()
        {
            try
            {
                return Ok(_managerInterface.GetAllManagers());
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetManagerById

        [HttpGet("{id}")]
        public IActionResult GetManagerById(int id)
        {
            try
            {
                Manager Manager = _managerInterface.GetManagerById(id);

                if (Manager != null)
                {
                    ReadManagerDto readMovie = _mapper.Map<ReadManagerDto>(Manager);
                    return Ok(readMovie);
                }

                return NotFound(new { Message = "Informed manager doesn't exist or wasn't found." });
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region AddManager

        [HttpPost]
        public IActionResult AddManager(CreateManagerDto managerDto)
        {
            try
            {
                Manager manager = _mapper.Map<Manager>(managerDto);
                _managerInterface.AddManager(manager);
                return CreatedAtAction(nameof(GetManagerById), new { manager.Id }, manager);
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

        #region UpdateManager

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateManagerDto updateMovie)
        {
            try
            {
                Manager Manager = _managerInterface.GetManagerById(id);
                _mapper.Map(updateMovie, Manager);
                _managerInterface.UpdateManager(Manager);
                return Ok(new { Message = "Manager successfully updated." });
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

        #region DeleteManager

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            try
            {
                _managerInterface.DeleteManager(id);
                return Ok(new { Message = "Manager successfully deleted." });
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
