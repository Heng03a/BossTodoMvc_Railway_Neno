using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BossTodoMvc.Application.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        // DEMO credentials (Phase 1)
        private const string DEMO_USER = "boss";
        private const string DEMO_PASSWORD = "123456";

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ Step 1: Validate credentials
        public bool ValidateCredentials(string username, string password)
        {
            return username == DEMO_USER && password == DEMO_PASSWORD;
        }

        // ✅ Step 2: Generate JWT
        public string GenerateToken(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var keyString = _configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(keyString))
                throw new InvalidOperationException("Jwt:Key is missing in configuration");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(keyString)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // SAFE PARSE WITH DEFAULT
            var expiresMinutes = 60;

            var configValue = _configuration["Jwt:ExpiresMinutes"];

            if (!string.IsNullOrWhiteSpace(configValue) &&
                int.TryParse(configValue, out var parsedMinutes))
            {
                expiresMinutes = parsedMinutes;
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
