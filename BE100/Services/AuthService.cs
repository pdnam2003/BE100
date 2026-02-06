using BE100.Data;
using BE100.DTOs.Response;
using BE100.DTOs.Request;
using BE100.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;


namespace BE100.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthService(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }


        public async Task<AuthResponseDto> LoginAsync(LoginRequest request)
        {
            var user = await _context.AppUser
                .FirstOrDefaultAsync(u => u.Username == request.UserName && u.PasswordHash == request.Password);
            if (user == null)
                throw new Exception("Invalid username or password");
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshTokenValue = _tokenService.GenerateRefreshToken();

            var refreshToken = new RefreshToken
            {
                token = refreshTokenValue
                ,
                user_id = user.Id
                ,
                ExpiredAt = DateTime.UtcNow.AddDays(7)
            };

            _context.RefreshToken
                .Add(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue
            };
        }


        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshTokenValue)
        {
            var refreshToken = await _context.RefreshToken
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt =>
                    rt.token == refreshTokenValue &&
                    rt.ExpiredAt > DateTime.UtcNow);

            if (refreshToken == null)
                throw new Exception("Refresh token không hợp lệ");

            var newAccessToken = _tokenService.GenerateAccessToken(refreshToken.User);
            var newRefreshTokenValue = _tokenService.GenerateRefreshToken();

            _context.RefreshToken.Remove(refreshToken);

            _context.RefreshToken.Add(new RefreshToken
            {
                token = newRefreshTokenValue,
                user_id = refreshToken.user_id,
                ExpiredAt = DateTime.UtcNow.AddDays(7)
            });

            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshTokenValue
            };
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var hash = Convert.ToBase64String(
                SHA256.HashData(Encoding.UTF8.GetBytes(password))
            );

            return hash == storedHash;
        }
    }
}
