using FluentResults;
using Microsoft.AspNetCore.Mvc;
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

        #region UserLogin

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

        #endregion

        #region ResetUserPassword

        [HttpPost]
        [Route("password-forget")]
        public IActionResult ForgetPassword(ForgetPasswordRequest request)
        {
            Result result = _loginService.ForgetPassword(request);

            if (result.IsFailed)
                return Unauthorized(result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                 .Select(message => message.Message));

            return Ok(result.Successes.Where(error => !string.IsNullOrEmpty(error.Message))
                                      .Select(message => message.Message));
        }

        #endregion

        #region ResetUserPassword

        [HttpPost]
        [Route("password-reset")]
        public IActionResult ResetUserPassword(PasswordResetRequest request)
        {
            Result result = _loginService.ResetUserPassword(request);

            if (result.IsFailed)
                return Unauthorized(result.Errors.Where(error => !string.IsNullOrEmpty(error.Message))
                                                 .Select(message => message.Message));

            return Ok(result.Successes.Where(error => !string.IsNullOrEmpty(error.Message))
                                      .Select(message => message.Message));
        }

        #endregion

    }
}
