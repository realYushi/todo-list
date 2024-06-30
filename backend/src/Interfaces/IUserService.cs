using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers(string role, string status);
        void DeleteUser(string id);
        UserDTO GetUser(string id);
        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateUser(string id, UserDTO user);
    }
}