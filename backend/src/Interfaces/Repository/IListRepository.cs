using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> GetAllListsAsync(Guid userId);
        Task<bool> DeleteListAsync(Guid listId, Guid userId);
        Task<List> GetListAsync(Guid listId, Guid userId);
        Task<List> UpdateListAsync(Guid listId, List list, Guid userId);
        Task<List> CreateListAsync(List list, Guid userId);
    }
}