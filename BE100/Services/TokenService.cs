using BE100.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BE100.Services
{
    public class TokenService
    {
        private const string SECRET_KEY = "THIS_IS_A_SUPER_SECRET_KEY_32_CHARS";

        public string GenerateAccessToken(AppUser user)
        {

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(SECRET_KEY)
            );

            var creds = new SigningCredentials(
              key,
              SecurityAlgorithms.HmacSha256
          );

            var token = new JwtSecurityToken(
              issuer: "myapp",
              audience: "myapp",
              claims: claims,
              expires: DateTime.UtcNow.AddMinutes(15),
              signingCredentials: creds
          );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
