using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace ToDoListAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        [SwaggerOperation("GetLists")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<ListDto>), description: "An array of task lists.")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "No lists found")]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetLists()
        {
            Guid userId = GetUserId();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User ID is required.");
            }

            var lists = await _listService.GetAllListsAsync(userId);
            if (lists == null || !lists.Any())
            {
                return NotFound("No lists found.");
            }

            return Ok(lists);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("DeleteList")]
        [SwaggerResponse(statusCode: 204, description: "Task list deleted successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public async Task<IActionResult> DeleteList([FromRoute] Guid id)
        {
            Guid userId = GetUserId();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User ID is required.");
            }
            if (!await _listService.DeleteListAsync(id, userId))
            {
                return NotFound($"List with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GetList")]
        [SwaggerResponse(statusCode: 200, type: typeof(ListDto), description: "Details of a specific task list")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public async Task<ActionResult<ListDto>> GetList([FromRoute] Guid id)
        {
            Guid userId = GetUserId();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User ID is required.");
            }
            ListDto list = await _listService.GetListAsync(id, userId);
            if (list == null)
            {
                return NotFound($"List with ID {id} not found.");
            }
            return Ok(list);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("UpdateList")]
        [SwaggerResponse(statusCode: 200, type: typeof(ListDto), description: "Task list updated successfully")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        [SwaggerResponse(statusCode: 404, description: "List not found")]
        public async Task<ActionResult<ListDto>> UpdateList([FromRoute] Guid id, [FromBody] ListDto listDto)
        {
            Guid userId = GetUserId();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User ID is required.");
            }
            ListDto updatedList = await _listService.UpdateListAsync(id, listDto, userId);
            if (updatedList == null)
            {
                return NotFound($"List with ID {id} not found.");
            }
            return Ok(updatedList);
        }

        [HttpPost]
        [SwaggerOperation("CreateList")]
        [SwaggerResponse(statusCode: 201, type: typeof(ListDto), description: "Task list created successfully")]
        [SwaggerResponse(statusCode: 400, description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, description: "Unauthorized")]
        public async Task<ActionResult<ListDto>> CreateList([FromBody] ListDto listDto)
        {
            Guid userId = GetUserId();
            if (userId == Guid.Empty)
            {
                return Unauthorized("User ID is required.");
            }
            if (listDto == null)
            {
                return BadRequest("List details are required.");
            }
            if (string.IsNullOrEmpty(listDto.Title))
            {
                return BadRequest("List name is required.");
            }
            ListDto createdList = await _listService.CreateListAsync(listDto, userId);
            return CreatedAtAction(nameof(GetList), new { id = createdList.ListId }, createdList);
        }

        private Guid GetUserId()
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }
            return Guid.Empty;
        }
    }
}
