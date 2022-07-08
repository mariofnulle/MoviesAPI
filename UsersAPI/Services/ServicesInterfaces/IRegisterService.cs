using FluentResults;
using UsersAPI.Data.Dto;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface IRegisterService
    {
        Result RegisterUser(CreateUserDto newUser);
        Result ActivateUserAccount(ActivateAccountRequest request);
    }
}
