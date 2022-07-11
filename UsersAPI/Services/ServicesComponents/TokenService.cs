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

        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] userRights = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("Xn2r5u8x/A?D(G+K")
                );

            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credencials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }

        #endregion
    }
}
