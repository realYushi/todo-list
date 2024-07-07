using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        bool DeleteUser(string id);
        UserDto GetUser(string userName, string email, string password);
        UserDto CreateUser(UserDto user);
        UserDto UpdateUser(string id, UserDto user);
    }
}