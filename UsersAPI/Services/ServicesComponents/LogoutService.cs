﻿using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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
