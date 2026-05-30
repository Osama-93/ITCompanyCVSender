using DataAccessTier.DataAccessModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.UsersSVC
{
    public class JwtService
    {
        public string GenerateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes("THIS_IS_A_SECRET_KEY_AT_LEAST_32_CHARS");

            var claims = new[]
            {
                new Claim("UserId",user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("RoleId", user.RoleId.ToString()),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
