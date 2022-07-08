using FluentResults;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface ILoginService
    {
        Result UserLogin(LoginRequest request);
    }
}
