using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        #region GetManager

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllManagers()
        {
            try
            {
                List<Manager> managers = _managerService.GetAllManagers();

                if(managers.Count > 0)
                    return Ok(managers);

                return NotFound("There isn't any managers registered.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllManagers(string name)
        {
            try
            {
                List<Manager> managers = _managerService.GetAllManagers(name);

                if (managers.Count > 0)
                    return Ok();

                return NotFound("There isn't any managers registered.");
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
                ReadManagerDto readManager = _managerService.GetManagerById(id);

                if (readManager != null)
                    return Ok(readManager);

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
        [Authorize(Roles = "admin")]
        public IActionResult AddManager(CreateManagerDto managerDto)
        {
            try
            {
                ReadManagerDto manager = _managerService.AddManager(managerDto);
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
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateManagerDto updateManager)
        {
            try
            {
                Result result = _managerService.UpdateManager(id, updateManager);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

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
        [Authorize(Roles = "admin")]
        public IActionResult DeleteManager(int id)
        {
            try
            {
                Result result = _managerService.DeleteManager(id);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

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
