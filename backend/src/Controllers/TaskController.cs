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
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// Retrieve all tasks
        /// </summary>
        /// <remarks>Fetches a list of tasks, optionally filtered by status or due date.</remarks>
        /// <param name="status">Filter tasks based on their status (e.g., pending, in_progress, completed).</param>
        /// <param name="dueDate">Filter tasks based on their due date in YYYY-MM-DD format.</param>
        /// <response code="200">A JSON array of task objects.</response>
        [HttpGet]
        [Route("/tasks")]
        [ValidateModelState]
        [SwaggerOperation("TasksGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Models.Task>), description: "A JSON array of task objects.")]
        public virtual IActionResult TasksGet([FromQuery(Name = "status")] string status, [FromQuery(Name = "due_date")] DateTime? dueDate)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Models.Task>));
            string exampleJson = null;
            exampleJson = "[ {\n  \"list_id\" : \"list_id\",\n  \"due_date\" : \"2000-01-23\",\n  \"description\" : \"description\",\n  \"id\" : \"id\",\n  \"title\" : \"title\",\n  \"status\" : \"pending\"\n}, {\n  \"list_id\" : \"list_id\",\n  \"due_date\" : \"2000-01-23\",\n  \"description\" : \"description\",\n  \"id\" : \"id\",\n  \"title\" : \"title\",\n  \"status\" : \"pending\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Models.Task>>(exampleJson)
            : default(List<Models.Task>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>Permanently deletes a task identified by its ID from the system.</remarks>
        /// <param name="id">The unique identifier of the task to delete.</param>
        /// <response code="204">Task deleted successfully. No content is returned.</response>
        [HttpDelete]
        [Route("/tasks/{id}")]
        [ValidateModelState]
        [SwaggerOperation("TasksIdDelete")]
        public virtual IActionResult TasksIdDelete([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a specific task
        /// </summary>
        /// <remarks>Fetches details of a specific task by its ID.</remarks>
        /// <param name="id"></param>
        /// <response code="200">Returns detailed information about the task.</response>
        [HttpGet]
        [Route("/tasks/{id}")]
        [ValidateModelState]
        [SwaggerOperation("TasksIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Models.Task), description: "Returns detailed information about the task.")]
        public virtual IActionResult TasksIdGet([FromRoute(Name = "id")][Required] string id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Task));
            string exampleJson = null;
            exampleJson = "{\n  \"list_id\" : \"list_id\",\n  \"due_date\" : \"2000-01-23\",\n  \"description\" : \"description\",\n  \"id\" : \"id\",\n  \"title\" : \"title\",\n  \"status\" : \"pending\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Models.Task>(exampleJson)
            : default(Models.Task);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <remarks>Updates the specified task with the provided details.</remarks>
        /// <param name="id">The unique identifier of the task to update.</param>
        /// <param name="tasksIdPutRequest"></param>
        /// <response code="200">Task updated successfully.</response>
        [HttpPut]
        [Route("/tasks/{id}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("TasksIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(Models.Task), description: "Task updated successfully.")]
        public virtual IActionResult TasksIdPut([FromRoute(Name = "id")][Required] string id, [FromBody] Models.Task tasksIdPutRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Task));
            string exampleJson = null;
            exampleJson = "{\n  \"list_id\" : \"list_id\",\n  \"due_date\" : \"2000-01-23\",\n  \"description\" : \"description\",\n  \"id\" : \"id\",\n  \"title\" : \"title\",\n  \"status\" : \"pending\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Models.Task>(exampleJson)
            : default(Models.Task);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>Creates a task with the given details.</remarks>
        /// <param name="tasksPostRequest"></param>
        /// <response code="201">Task created successfully.</response>
        [HttpPost]
        [Route("/tasks")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("TasksPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(Models.Task), description: "Task created successfully.")]
        public virtual IActionResult TasksPost([FromBody] Models.Task tasksPostRequest)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Task));
            string exampleJson = null;
            exampleJson = "{\n  \"list_id\" : \"list_id\",\n  \"due_date\" : \"2000-01-23\",\n  \"description\" : \"description\",\n  \"id\" : \"id\",\n  \"title\" : \"title\",\n  \"status\" : \"pending\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Models.Task>(exampleJson)
            : default(Models.Task);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}