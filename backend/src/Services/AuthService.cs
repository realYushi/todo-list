using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoListAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IListService _listService;

        public AuthService(IUserService userService, IConfiguration configuration, IListService listService)
        {
            _userService = userService;
            _configuration = configuration;
            _listService = listService;
        }

        public async Task<string> Login(UserDto login, HttpContext httpContext)
        {
            try
            {
                var user = await _userService.GetUserAsync(login.Username);
                if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid username or password");
                }

                var token = GenerateJwtToken(user);
                SetJwtCookie(httpContext, token);
                return token;
            }
            catch (UnauthorizedAccessException)
            {
                throw; // Re-throw the exception to be caught in the controller
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception in Login method: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw; // Re-throw the exception to be caught in the controller
            }
        }



        private void SetJwtCookie(HttpContext httpContext, string token)
        {
            httpContext.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Domain = ".yushi91.com",
            });
        }

        private string GenerateJwtToken(UserDto user)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? _configuration["Jwt:Key"];
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? _configuration["Jwt:Issuer"];
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? _configuration["Jwt:Audience"];

            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            {
                throw new InvalidOperationException("JWT configuration is incomplete");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
    };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserDto> Register(UserDto registration)
        {
            try
            {
                // Check if user already exists
                var existingUser = await _userService.GetUserAsync(registration.Username);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("User already exists");
                }
            }
            catch (Exception ex) when (ex.Message.Contains("not found"))
            {
                // user does not exist, continue with registration
            }

            // Create the user
            var createdUser = await _userService.CreateUserAsync(registration);

            // Create a default list for the new user
            var defaultList = new ListDto { };
            await _listService.CreateListAsync(defaultList, (Guid)createdUser.UserId);

            return createdUser;
        }
    }
}
