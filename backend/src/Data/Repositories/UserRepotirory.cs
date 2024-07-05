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

        public void DeleteUser(string userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

        public IEnumerable<Models.User> GetAllUsers(string userId)
        {
            return context.Users.Where(user => user.UserId == userId);
        }

        public Models.User GetUser(string userId)
        {
            return context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public Models.User UpdateUser(string userId, Models.User user)
        {
            user.UserId = userId; // Ensure UserId is set correctly
            var updatedUser = context.Users.Update(user);
            return updatedUser.Entity;
        }
    }
}