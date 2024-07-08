using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace ToDoListAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpPost]

        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User details are required.");
            }
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { userName = createdUser.Username, email = createdUser.Email }, createdUser);
        }

        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (!result)
            {
                return NotFound($"User with ID {userId} not found.");
            }
            return NoContent();
        }

        [HttpGet("{userName}/{email}")]

        public async Task<ActionResult<UserDto>> GetUser([FromRoute] string userName, [FromRoute] string email)
        {
            var user = await _userService.GetUserAsync(userName, email);
            if (user == null)
            {
                return NotFound($"User with username {userName} and email {email} not found.");
            }
            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] Guid userId, [FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User details are required.");
            }
            var updatedUser = await _userService.UpdateUserAsync(user, userId);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }
            return Ok(updatedUser);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}