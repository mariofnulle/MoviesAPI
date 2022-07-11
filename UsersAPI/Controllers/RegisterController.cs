using FluentResults;
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

        #region RegisterUser

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

        #endregion

        #region ActivateUserAccount

        [HttpGet]
        [Route("activation")]
        public IActionResult ActivateUserAccount([FromQuery] ActivateAccountRequest request)
        {
            Result result = _registerService.ActivateUserAccount(request);

            if (result.IsFailed)
                return StatusCode(500, result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                    .Select(message => message.Message));

            return Ok(new { Message = "E-mail successfully confirmed." });
        }

        #endregion
    }
}
