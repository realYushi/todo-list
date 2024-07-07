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
    public class ListController : ControllerBase
    {
        private readonly ListService _listService;

        public ListController(ListService listService)
        {
            _listService = listService;
        }

        /// <summary>
        /// Get all lists for the authenticated user
        /// </summary>
        /// <returns>An array of task lists</returns>
        /// <response code="200">Returns the list of task lists</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">No lists found</response>
        [HttpGet]
        [SwaggerOperation("GetLists")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ListDto>), description: "An array of task lists.")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "No lists found")]
        public ActionResult<IEnumerable<ListDto>> GetLists()
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }

            var lists = _listService.GetAllLists(userId);
            if (lists == null || !lists.Any())
            {
                return NotFound("No lists found.");
            }

            return Ok(lists);
        }

        /// <summary>
        /// Delete a list
        /// </summary>
        /// <param name="id">Unique identifier of the task list to delete</param>
        /// <returns>No content</returns>
        /// <response code="204">Task list deleted successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">List not found</response>
        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteList")]
        [SwaggerResponse(statusCode: 204, description: "Task list deleted successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public IActionResult DeleteList([FromRoute] string id)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            if (!_listService.DeleteList(id, userId))
            {
                return NotFound($"List with ID {id} not found.");
            }
            return NoContent();
        }

        /// <summary>
        /// Retrieve a specific list by ID
        /// </summary>
        /// <param name="id">Unique identifier of the task list</param>
        /// <returns>Details of a specific task list</returns>
        /// <response code="200">Returns the requested task list</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">List not found</response>
        [HttpGet("{id}")]
        [SwaggerOperation("GetList")]
        [SwaggerResponse(statusCode: 200, type: typeof(ListDto), description: "Details of a specific task list")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public ActionResult<ListDto> GetList([FromRoute] string id)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            ListDto list = _listService.GetList(id, userId);
            if (list == null)
            {
                return NotFound($"List with ID {id} not found.");
            }
            return Ok(list);
        }

        /// <summary>
        /// Update an existing list
        /// </summary>
        /// <param name="id">Unique identifier of the task list to update</param>
        /// <param name="listDto">Updated list data</param>
        /// <returns>Updated task list</returns>
        /// <response code="200">Task list updated successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">List not found</response>
        [HttpPut("{id}")]
        [SwaggerOperation("UpdateList")]
        [SwaggerResponse(statusCode: 200, type: typeof(ListDto), description: "Task list updated successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public ActionResult<ListDto> UpdateList([FromRoute] string id, [FromBody] ListDto listDto)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            ListDto updatedList = _listService.UpdateList(id, listDto, userId);
            if (updatedList == null)
            {
                return NotFound($"List with ID {id} not found.");
            }
            return Ok(updatedList);
        }

        /// <summary>
        /// Create a new list
        /// </summary>
        /// <param name="listDto">New list data</param>
        /// <returns>Newly created task list</returns>
        /// <response code="201">Task list created successfully</response>
        /// <response code="400">Invalid input</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [SwaggerOperation("CreateList")]
        [SwaggerResponse(statusCode: 201, type: typeof(ListDto), description: "Task list created successfully")]
        [SwaggerResponse(statusCode: 400, description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        public ActionResult<ListDto> CreateList([FromBody] ListDto listDto)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is required.");
            }
            if (listDto == null)
            {
                return BadRequest("List details are required.");
            }
            if (string.IsNullOrEmpty(listDto.Name))
            {
                return BadRequest("List name is required.");
            }
            ListDto createdList = _listService.CreateList(listDto, userId);
            return CreatedAtAction(nameof(GetList), new { id = createdList.Id }, createdList);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}