using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManger;
        private readonly IMailService _emailService;

        public RegisterService(IMapper mapper, UserManager<CustomIdentityUser> userManger, IMailService emailService)
        {
            _mapper = mapper;
            _userManger = userManger;
            _emailService = emailService;
        }

        #region ActivateUserAccount

        public Result ActivateUserAccount(ActivateAccountRequest request)
        {
            CustomIdentityUser identityUser = _userManger.Users.FirstOrDefault(user => user.Id == request.UserId);
            IdentityResult identityResult = _userManger.ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

            if (identityResult.Succeeded)
                return Result.Ok();

            return Result.Fail("Error activating account.");
        }

        #endregion

        #region RegisterUser

        public Result RegisterUser(CreateUserDto newUser)
        {
            User user = _mapper.Map<User>(newUser);
            CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(user);
            Task<IdentityResult> identityResult = _userManger.CreateAsync(identityUser, newUser.Password);
            _userManger.AddToRoleAsync(identityUser, "regular");

            if (identityResult.Result.Succeeded)
            {
                string emailConfirmation = _userManger.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                string encodedCode = HttpUtility.UrlEncode(emailConfirmation);

                _emailService.SendMail(new[] { identityUser.Email }, "Activation Link", identityUser.Id, encodedCode);

                return Result.Ok().WithSuccess(encodedCode);
            }

            return Result.Fail("An error ocurred when registering a new user.");
        }

        #endregion
    }
}
