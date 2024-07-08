using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Models.User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid userId);
        Task<Models.User> GetUserAsync(string userName, string email);
        Task<Models.User> CreateUserAsync(Models.User user);
        Task<Models.User> UpdateUserAsync(Guid userId, Models.User user);
    }
}