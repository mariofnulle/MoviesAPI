using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsersAPI.Data.Requests;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMailService _emailService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, ITokenService tokenService, IMailService emailService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        #region ForgetPassword

        public Result ForgetPassword(ForgetPasswordRequest request)
        {
            IdentityUser<int> identityUser = GetUserByEmail(request.Email);

            if (identityUser != null)
            {
                string resetCode = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                //TODO: Send code to email.
                return Result.Ok().WithSuccess(resetCode);
            }

            return Result.Fail("Failed to create password reset token.");
        }

        #endregion

        #region ResetUserPassword

        public Result ResetUserPassword(PasswordResetRequest request)
        {
            IdentityUser<int> identityUser = GetUserByEmail(request.Email);
            IdentityResult identityResult = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (identityResult.Succeeded)
                return Result.Ok().WithSuccess("Password successfully redefined");

            return Result.Fail("Failed to reset password.");
        }

        #endregion

        #region UserLogin

        public Result UserLogin(LoginRequest request)
        {
            Task<SignInResult> identityResult = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (identityResult.Result.Succeeded)
            {
                IdentityUser<int> identityUser = _signInManager.UserManager.Users
                                   .FirstOrDefault(user => user.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, 
                                    _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login failed.");
        }

        #endregion

        #region Private Methods

        #region GetUserByEmail

        private IdentityUser<int> GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }

        #endregion

        #endregion
    }
}
