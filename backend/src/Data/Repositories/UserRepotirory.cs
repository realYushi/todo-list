using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
namespace ToDoListAPI.Data.Repositories
{
    public class UserRepository : IUserRepository

    {
        private ToDoListContext context;

        public UserRepository(ToDoListContext context)
        {
            this.context = context;
        }

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