using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Components;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAddress _addressInterface;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _addressInterface = new AddressComponent(context);
        }

        #region GetAddress

        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            try
            {
                return Ok(_addressInterface.GetAllAddress());
            }
            catch (Exception message)
            {
                return StatusCode(500, message.Message);
            }
        }

        #endregion

        #region GetAddressById

        [HttpGet ("{id}")]
        public IActionResult GetAddressById(int id)
        {
            try
            {
                Address Address = _addressInterface.GetAddressById(id);

                if (Address != null)
                {
                    ReadAddressDto readMovie = _mapper.Map<ReadAddressDto>(Address);
                    readMovie.LookupDate = DateTime.Now;
                    return Ok(readMovie);
                }

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
        public IActionResult AddAddress([FromBody] CreateAddressDto newMovie)
        {
            try
            {
                Address Address = _mapper.Map<Address>(newMovie);
                _addressInterface.AddAddress(Address);
                return CreatedAtAction(nameof(GetAddressById), new { Address.Id }, Address);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateAddressDto updateMovie)
        {
            try
            {
                Address Address = _addressInterface.GetAddressById(id);
                _mapper.Map(updateMovie, Address);
                _addressInterface.UpdateAddress(Address);
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
        public IActionResult DeleteAddress(int id)
        {
            try
            {
                _addressInterface.DeleteAddress(id);
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
