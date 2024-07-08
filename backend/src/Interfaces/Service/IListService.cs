using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
  public interface IListService
  {
    Task<ListDto> CreateListAsync(ListDto list, Guid userId);
    Task<bool> DeleteListAsync(Guid listId, Guid userId);
    Task<IEnumerable<ListDto>> GetAllListsAsync(Guid userId);
    Task<ListDto> GetListAsync(Guid listId, Guid userId);
    Task<ListDto> UpdateListAsync(Guid listId, ListDto list, Guid userId);
  }
}