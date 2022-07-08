using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsersAPI.Data.Requests;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result UserLogin(LoginRequest request)
        {
            var identityResult = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (identityResult.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                                   .FirstOrDefault(user => user.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login failed.");
        }
    }
}
