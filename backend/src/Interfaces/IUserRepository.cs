using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(string role, string status);
        void DeleteUser(string id);
        User GetUser(string id);
        User CreateUser(User user);
        User UpdateUser(string id, User user);
    }
}