using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using UsersAPI.Data.Dto;
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

        public Result RegisterUser(CreateUserDto newUser)
        {
            User user = _mapper.Map<User>(newUser);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            var identityResult = _userManger.CreateAsync(identityUser, newUser.Password);

            if (identityResult.Result.Succeeded)
                return Result.Ok();

            return Result.Fail("An error ocurred when registering a new user.");
        }
    }
}
