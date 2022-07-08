using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutService _logoutService;

        public LogoutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutService.Logout();

            if(result.IsFailed)
                return Unauthorized(result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                 .Select(message => message.Message));

            return Ok(result.Successes.Where(successes => !string.IsNullOrEmpty(successes.Message))
                                                 .Select(message => message.Message));
        }
    }
}
