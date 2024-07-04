using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ToDoListAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ToDoListContext context;

        public UserRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public Models.User CreateUser(Models.User user)
        {
            var createdUser = context.Users.Add(user);
            return createdUser.Entity;
        }

        public void DeleteUser(String id)
        {
            context.Users.Remove(context.Users.Find(id));
        }

        public IEnumerable<Models.User> GetAllUsers(String role, String status)
        {
            var users = context.Users.Where(user => user.Role == role && user.Status == status);
            return users;
        }

        public Models.User GetUser(String id)
        {
            var user = context.Users.Find(id);
            return user;
        }

        public Models.User UpdateUser(String id, Models.User user)
        {
            var updatedUser = context.Users.Update(user);
            return updatedUser.Entity;
        }
    }
}