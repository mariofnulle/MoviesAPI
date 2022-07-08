using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManger;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManger)
        {
            _mapper = mapper;
            _userManger = userManger;
        }

        public Result ActivateUserAccount(ActivateAccountRequest request)
        {
            var identityUser = _userManger.Users.FirstOrDefault(user => user.Id == request.UserId);
            var identityResult = _userManger.ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

            if (identityResult.Succeeded)
                return Result.Ok();

            return Result.Fail("Error activating account.");
        }

        public Result RegisterUser(CreateUserDto newUser)
        {
            User user = _mapper.Map<User>(newUser);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManger.CreateAsync(identityUser, newUser.Password);

            if (identityResult.Result.Succeeded)
            {
                var emailConfirmation = _userManger.GenerateEmailConfirmationTokenAsync(identityUser);
                return Result.Ok().WithSuccess(emailConfirmation.Result);
            }

            return Result.Fail("An error ocurred when registering a new user.");
        }
    }
}
