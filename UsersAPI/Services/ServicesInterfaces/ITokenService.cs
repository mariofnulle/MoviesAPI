using Microsoft.AspNetCore.Identity;
using UsersAPI.Models;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface ITokenService
    {
        Token CreateToken(IdentityUser<int> user);
    }
}
