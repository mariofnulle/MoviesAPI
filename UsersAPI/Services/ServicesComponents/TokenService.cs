using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAPI.Models;
using UsersAPI.Services.ServicesInterfaces;

namespace UsersAPI.Services.ServicesComponents
{
    public class TokenService : ITokenService
    {
        #region CreateToken

        public Token CreateToken(CustomIdentityUser user, string role)
        {
            Claim[] userRights = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("Xn2r5u8x/A?D(G+K"));

            SigningCredentials credencials = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(
                claims: userRights,
                signingCredentials: credencials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }

        #endregion
    }
}
