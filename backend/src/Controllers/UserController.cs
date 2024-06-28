using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using ToDoListAPI.Attributes;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <remarks>Fetches a list of all users in the system, optionally filtered by role or status.</remarks>
        /// <param name="role">Filter users by their role (e.g., admin, user).</param>
        /// <param name="status">Filter users by their current status (e.g., active, inactive).</param>
        /// <response code="200">A JSON array of user objects.</response>
        [HttpGet]
        [Route("/users")]
        [ValidateModelState]
        [SwaggerOperation("UsersGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "A JSON array of user objects.")]
        public virtual IActionResult UsersGet([FromQuery(Name = "role")] string role, [FromQuery(Name = "status")] string status)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<User>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"role\" : \"role\",\n  \"id\" : \"id\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"status\" : \"status\"\n}, {\n  \"role\" : \"role\",\n  \"id\" : \"id\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"status\" : \"status\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<User>>(exampleJson)
            : default(List<User>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <remarks>Deletes a specific user identified by their unique ID from the system.</remarks>
        /// <param name="id">Unique identifier of the user to delete.</param>
        /// <response code="204">User deleted successfully.</response>
        [HttpDelete]
        [Route("/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UsersIdDelete")]
        public virtual IActionResult UsersIdDelete([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a specific user by ID
        /// </summary>
        /// <remarks>Returns the details of a specific user identified by their unique ID.</remarks>
        /// <param name="id">Unique identifier of the user to retrieve.</param>
        /// <response code="200">Detailed information about the user.</response>
        [HttpGet]
        [Route("/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UsersIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "Detailed information about the user.")]
        public virtual IActionResult UsersIdGet([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(User));
            string exampleJson = null;
            exampleJson = "{\n  \"role\" : \"role\",\n  \"id\" : \"id\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"status\" : \"status\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<User>(exampleJson)
            : default(User);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <remarks>Updates the details of an existing user identified by their unique ID.</remarks>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <response code="200">User updated successfully.</response>
        [HttpPut]
        [Route("/users/{id}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UsersIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "User updated successfully.")]
        public virtual IActionResult UsersIdPut([FromRoute(Name = "id")][Required] string id, [FromBody] User user)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(User));
            string exampleJson = null;
            exampleJson = "{\n  \"role\" : \"role\",\n  \"id\" : \"id\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"status\" : \"status\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<User>(exampleJson)
            : default(User);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
