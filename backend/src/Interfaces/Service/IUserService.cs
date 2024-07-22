using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(string userName);
        Task<UserDto> UpdateUserAsync(UserDto user, Guid userId);
    }
}