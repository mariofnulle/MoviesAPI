using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsersAPI.Data.Requests;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult UserLogin(LoginRequest request)
        {
            Result result = _loginService.UserLogin(request);

            if (result.IsFailed)
                return Unauthorized(result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                 .Select(message => message.Message));

            return Ok(result.Successes.Where(error => !string.IsNullOrEmpty(error.Message))
                                      .Select(message => message.Message));
        }
    }
}
