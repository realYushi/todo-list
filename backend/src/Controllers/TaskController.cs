using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
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
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all tasks", Description = "Retrieves all tasks for the authenticated user")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of tasks retrieved successfully", typeof(IEnumerable<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAllTasks()
        {
            Guid userId = GetUserId();
            var tasks = await _taskService.GetAllTasksAsync(userId);
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a task", Description = "Deletes a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Task deleted successfully")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            Guid userId = GetUserId();
            bool deleted = await _taskService.DeleteTaskAsync(id, userId);
            if (!deleted)
            {
                return NotFound($"Task with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a task", Description = "Retrieves a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task retrieved successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public async Task<ActionResult<TaskDto>> GetTask(Guid id)
        {
            Guid userId = GetUserId();
            var task = await _taskService.GetTaskAsync(id, userId);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a task", Description = "Updates a specific task by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task updated successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
        public async Task<ActionResult<TaskDto>> UpdateTask(Guid id, [FromBody] TaskDto taskDto)
        {
            Guid userId = GetUserId();
            var updatedTask = await _taskService.UpdateTaskAsync(id, taskDto, userId);
            if (updatedTask == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }
            return Ok(updatedTask);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a task", Description = "Creates a new task")]
        [SwaggerResponse(StatusCodes.Status201Created, "Task created successfully", typeof(TaskDto))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is not authorized")]
        public async Task<ActionResult<TaskDto>> CreateTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid userId = GetUserId();
            _logger.LogInformation($"Creating task for user: {userId}");
            var createdTask = await _taskService.CreateTaskAsync(taskDto, userId);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.TaskId }, createdTask);
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                throw new UnauthorizedAccessException("User ID is required and must be a valid GUID.");
            }
            return userId;
        }
    }
}