using UsersAPI.Models;

namespace UsersAPI.Services.ServicesInterfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser user, string v);
    }
}
