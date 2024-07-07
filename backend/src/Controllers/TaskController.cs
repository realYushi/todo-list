using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;

namespace ToDoListAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get all tasks for the authenticated user
        /// </summary>
        /// <returns>A list of tasks</returns>
        /// <response code="200">Returns the list of tasks</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all tasks", Description = "Retrieves all tasks for the authenticated user")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of tasks retrieved successfully", typeof(IEnumerable<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        public ActionResult<IEnumerable<TaskDto>> GetAllTasks()
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            var tasks = _taskService.GetAllTasks(userId);
            return Ok(tasks);
        }

        /// <summary>
        /// Delete a specific task
        /// </summary>
        /// <param name="id">The ID of the task to delete</param>
        /// <response code="204">Task deleted successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Task not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a task", Description = "Deletes a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Task deleted successfully")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public IActionResult DeleteTask(string id)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            bool found = _taskService.DeleteTask(id, userId);
            if (!found)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return NoContent();
        }

        /// <summary>
        /// Get a specific task
        /// </summary>
        /// <param name="id">The ID of the task to retrieve</param>
        /// <returns>The requested task</returns>
        /// <response code="200">Returns the requested task</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Task not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a task", Description = "Retrieves a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task retrieved successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public ActionResult<TaskDto> GetTask(string id)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            var task = _taskService.GetTask(id, userId);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return Ok(task);
        }

        /// <summary>
        /// Update a specific task
        /// </summary>
        /// <param name="id">The ID of the task to update</param>
        /// <param name="taskDto">The updated task data</param>
        /// <returns>The updated task</returns>
        /// <response code="200">Task updated successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Task not found</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a task", Description = "Updates a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task updated successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public ActionResult<TaskDto> UpdateTask(string id, [FromBody] TaskDto taskDto)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            var updatedTask = _taskService.UpdateTask(id, taskDto, userId);
            if (updatedTask == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return Ok(updatedTask);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="taskDto">The task data to create</param>
        /// <returns>The created task</returns>
        /// <response code="201">Task created successfully</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a task", Description = "Creates a new task")]
        [SwaggerResponse(StatusCodes.Status201Created, "Task created successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        public ActionResult<TaskDto> CreateTask([FromBody] TaskDto taskDto)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            var createdTask = _taskService.CreateTask(taskDto, userId);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}