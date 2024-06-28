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
    public class ListController : ControllerBase
    {
        [HttpGet]
        [Route("/lists")]
        [ValidateModelState]
        [SwaggerOperation("ListsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<List>), description: "An array of task lists.")]
        public virtual IActionResult ListsGet([FromQuery(Name = "name")] string name)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<List>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"user_id\" : \"user_id\",\n  \"name\" : \"name\",\n  \"description\" : \"description\",\n  \"id\" : \"id\"\n}, {\n  \"user_id\" : \"user_id\",\n  \"name\" : \"name\",\n  \"description\" : \"description\",\n  \"id\" : \"id\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<List>>(exampleJson)
            : default(List<List>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete a list
        /// </summary>
        /// <remarks>Permanently deletes a specific task list, identified by its ID.</remarks>
        /// <param name="id">Unique identifier of the task list to delete.</param>
        /// <response code="204">Task list deleted successfully.</response>
        [HttpDelete]
        [Route("/lists/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ListsIdDelete")]
        public virtual IActionResult ListsIdDelete([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a specific list by ID
        /// </summary>
        /// <remarks>Returns detailed information about a specific task list, identified by its ID.</remarks>
        /// <param name="id">Unique identifier of the task list.</param>
        /// <response code="200">Details of a specific task list.</response>
        [HttpGet]
        [Route("/lists/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ListsIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List), description: "Details of a specific task list.")]
        public virtual IActionResult ListsIdGet([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List));
            string exampleJson = null;
            exampleJson = "{\n  \"user_id\" : \"user_id\",\n  \"name\" : \"name\",\n  \"description\" : \"description\",\n  \"id\" : \"id\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List>(exampleJson)
            : default(List);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing list
        /// </summary>
        /// <remarks>Updates details of a specific task list using the provided data.</remarks>
        /// <param name="id">Unique identifier of the task list to update.</param>
        /// <param name="listsIdPutRequest"></param>
        /// <response code="200">Task list updated successfully.</response>
        [HttpPut]
        [Route("/lists/{id}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("ListsIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(List), description: "Task list updated successfully.")]
        public virtual IActionResult ListsIdPut([FromRoute(Name = "id")][Required] string id, [FromBody] List listsIdPutRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List));
            string exampleJson = null;
            exampleJson = "{\n  \"user_id\" : \"user_id\",\n  \"name\" : \"name\",\n  \"description\" : \"description\",\n  \"id\" : \"id\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List>(exampleJson)
            : default(List);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a new list
        /// </summary>
        /// <remarks>Creates a new task list with specified name and description.</remarks>
        /// <param name="listsPostRequest"></param>
        /// <response code="201">Task list created successfully.</response>
        [HttpPost]
        [Route("/lists")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("ListsPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(List), description: "Task list created successfully.")]
        public virtual IActionResult ListsPost([FromBody] List listsPostRequest)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(List));
            string exampleJson = null;
            exampleJson = "{\n  \"user_id\" : \"user_id\",\n  \"name\" : \"name\",\n  \"description\" : \"description\",\n  \"id\" : \"id\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List>(exampleJson)
            : default(List);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}