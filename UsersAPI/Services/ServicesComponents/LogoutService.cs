using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        #region Logout

        public Result Logout()
        {
            Task identityResult = _signInManager.SignOutAsync();

            if (identityResult.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Logout failed.");
        }

        #endregion
    }
}
