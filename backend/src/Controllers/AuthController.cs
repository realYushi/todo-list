using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Interfaces;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserDto registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                UserDto user = await _authService.Register(registration);
                return CreatedAtAction(nameof(Login), new { username = user.Username }, user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto loginDto)
        {
            try
            {
                string token = await _authService.Login(loginDto, HttpContext);
                return Ok(new { message = "Login successful", token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid username or password");
            }
        }


        [HttpPost("logout")]
        public ActionResult<string> Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok("Logout successful.");
        }
    }
}


