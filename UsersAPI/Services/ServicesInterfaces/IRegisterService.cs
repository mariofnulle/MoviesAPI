using FluentResults;
using UsersAPI.Data.Dto;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface IRegisterService
    {
        Result RegisterUser(CreateUserDto newUser);
    }
}
