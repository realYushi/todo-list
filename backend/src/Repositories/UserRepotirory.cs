using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
namespace ToDoListAPI.Repositories
{
    public class UserRepository : IUserRepository

    {
        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers(string role, string status)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(string id, User user)
        {
            throw new NotImplementedException();
        }
    }
}