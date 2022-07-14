using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        #region GetAddress

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetAllAddress()
        {
            try
            {
                List<Address> address = _addressService.GetAllAddress();

                if (address.Count > 0)
                    return Ok(address);

                return NotFound("There isn't any addresses registered.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetAllAddress(string addressName, string neighbordhood, int? number)
        {
            try
            {
                List<Address> address = _addressService.GetAllAddress(addressName,neighbordhood,number);

                if (address.Count > 0)
                    return Ok(address);

                return NotFound("There isn't any addresses registered within the filter criteria.");
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetAddressById

        [HttpGet ("{id}")]
        [Authorize(Roles = "admin, regular")]
        public IActionResult GetAddressById(int id)
        {
            try
            {
                ReadAddressDto readAddress = _addressService.GetAddressById(id);

                if (readAddress != null)
                    return Ok(readAddress);

                return NotFound(new { Message = "Informed address doesn't exist or wasn't found." });
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region AddAddress

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddAddress([FromBody] CreateAddressDto newAddress)
        {
            try
            {
                ReadAddressDto address = _addressService.AddAddress(newAddress);
                return CreatedAtAction(nameof(GetAddressById), new { address.Id }, address);
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

        #region UpdateAddress

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateAddressDto updateAddress)
        {
            try
            {
                Result result = _addressService.UpdateAddress(id, updateAddress);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new {Message = "Address successfully updated." });
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

        #region DeleteAddress

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteAddress(int id)
        {
            try
            {
                Result result = _addressService.DeleteAddress(id);

                if (result.IsFailed)
                    return NotFound(result.Errors.FirstOrDefault(error => !string.IsNullOrEmpty(error.Message)).Message);

                return Ok(new { Message = "Address successfully deleted." });
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
