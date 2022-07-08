﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] CreateUserDto newUser)
        {
            Result result = _registerService.RegisterUser(newUser);

            if (result.IsFailed)
                return StatusCode(500, result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                    .Select(message => message.Message));

            return Ok(result.Successes.Where(success => !string.IsNullOrEmpty(success.Message))
                                      .Select(message => message.Message));
        }

        [HttpPost]
        [Route("activation")]
        public IActionResult ActivateUserAccount([FromBody] ActivateAccountRequest request)
        {
            Result result = _registerService.ActivateUserAccount(request);

            if (result.IsFailed)
                return StatusCode(500, result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                    .Select(message => message.Message));

            return Ok(result.Successes.Where(success => !string.IsNullOrEmpty(success.Message))
                                      .Select(message => message.Message));
        }
    }
}
