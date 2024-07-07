using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace ToDoListAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Login(UserDto login)
        {
            var user = _userService.GetUser(login.UserName, login.Email, login.Password);
            if (user != null)
            {
                return GenerateJwtToken(user);
            }
            return null;
        }

        private string GenerateJwtToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Adjust as necessary
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserDto Register(UserDto registration)
        {
            if (_userService.GetUser(registration.UserName, registration.Email, registration.Password) != null)
            {
                return null; // User already exists
            }
            return _userService.CreateUser(registration);
        }


        public void Logout()
        {
            // Client-side action: Remove the stored JWT token
            // No server-side action is needed unless implementing token blacklisting
        }
    }
}
