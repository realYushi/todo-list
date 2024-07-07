using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Interfaces;
using ToDoListAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _authService = authService;
            _userService = userService;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="registration">User registration details</param>
        /// <returns>Registration result</returns>
        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register a new user", Description = "Creates a new user account")]
        [SwaggerResponse(StatusCodes.Status201Created, "Registration successful", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input or user already exists")]
        public ActionResult<string> Register([FromBody] UserDto registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserDto user = _authService.Register(registration);
                return CreatedAtAction(nameof(Login), new { username = user.UserName }, "Registration successful.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="login">User login credentials</param>
        /// <returns>Login result</returns>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Authenticate a user", Description = "Logs in a user and returns an authentication token")]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successful", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid username, email, or password")]
        public ActionResult<string> Login([FromBody] UserDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string token = _authService.Login(login);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid username, email, or password.");
                }

                SetAuthCookie(token);
                return Ok("Login successful.");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Note: Ensure that _logger is properly injected in the constructor
                Console.Error.WriteLine($"An error occurred during login: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during login.");
            }
        }

        /// <summary>
        /// Log out the current user
        /// </summary>
        /// <returns>Logout result</returns>
        [HttpPost("logout")]
        [SwaggerOperation(Summary = "Log out the current user", Description = "Logs out the authenticated user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Logout successful", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authenticated")]
        public ActionResult<string> Logout()
        {
            // Clear the authentication cookie
            Response.Cookies.Delete("token");
            return Ok("Logout successful.");
        }

        private void SetAuthCookie(string token)
        {
            Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(7),
                SameSite = SameSiteMode.Strict
            });
        }
    }
}