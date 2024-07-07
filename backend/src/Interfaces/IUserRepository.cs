using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        bool DeleteUser(string id);
        User GetUser(string userName, string email);
        User CreateUser(User user);
        User UpdateUser(string id, User user);
    }
}
