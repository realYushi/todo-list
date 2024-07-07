using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using ToDoListAPI.Attributes;
using ToDoListAPI.Models;
using ToDoListAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <remarks>Fetches a list of all users in the system.</remarks>
        /// <response code="200">A JSON array of user objects</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [SwaggerOperation("GetUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "A JSON array of user objects")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            return Ok(_userService.GetAllUsers());
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <remarks>Creates a new user with the provided details.</remarks>
        /// <param name="user">User details</param>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Invalid input</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 201, type: typeof(User), description: "User created successfully")]
        [SwaggerResponse(statusCode: 400, description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        public ActionResult<User> CreateUser([FromBody] UserDto user)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            if (user == null)
            {
                return BadRequest("User details are required.");
            }
            var createdUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <remarks>Deletes a specific user identified by their unique ID from the system.</remarks>
        /// <param name="id">Unique identifier of the user to delete</param>
        /// <response code="204">User deleted successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse(statusCode: 204, description: "User deleted successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "User not found")]
        public IActionResult DeleteUser([FromRoute] string id)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            if (!_userService.DeleteUser(id))
            {
                return NotFound($"User with ID {id} not found.");
            }
            return NoContent();
        }

        /// <summary>
        /// Retrieve a specific user by ID
        /// </summary>
        /// <remarks>Returns the details of a specific user identified by their unique ID.</remarks>
        /// <param name="id">Unique identifier of the user to retrieve</param>
        /// <response code="200">Detailed information about the user</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation("GetUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "Detailed information about the user")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "User not found")]
        public ActionResult<User> GetUser([FromRoute] string email, [FromRoute] string password)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            var user = _userService.GetUser(userId, email, password);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }
            return Ok(user);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <remarks>Updates the details of an existing user identified by their unique ID.</remarks>
        /// <param name="id">Unique identifier of the user to update</param>
        /// <param name="user">Updated user details</param>
        /// <response code="200">User updated successfully</response>
        /// <response code="400">Invalid input</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        [HttpPut("{id}")]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "User updated successfully")]
        [SwaggerResponse(statusCode: 400, description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "User not found")]
        public ActionResult<User> UpdateUser([FromRoute] string id, [FromBody] UserDto user)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            if (user == null)
            {
                return BadRequest("User details are required.");
            }
            var updatedUser = _userService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(updatedUser);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}