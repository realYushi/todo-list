using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers(String userId);
        void DeleteUser(string id);
        UserDto GetUser(string id);
        UserDto CreateUser(UserDto user);
        UserDto UpdateUser(string id, UserDto user);
    }
}