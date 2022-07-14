using FluentResults;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface ILoginService
    {
        Result UserLogin(LoginRequest request);
        Result ResetUserPassword(PasswordResetRequest request);
        Result ForgetPassword(ForgetPasswordRequest request);
    }
}
