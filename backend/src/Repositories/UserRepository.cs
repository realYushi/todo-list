using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoListContext _context;

        public UserRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<Models.User> CreateUserAsync(Models.User user)
        {
            var createdUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return createdUser.Entity;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null) return false;

                // Delete associated tasks
                var tasks = await _context.Tasks.Where(t => t.List.UserId == userId).ToListAsync();
                _context.Tasks.RemoveRange(tasks);

                // Delete associated lists
                var lists = await _context.Lists.Where(l => l.UserId == userId).ToListAsync();
                _context.Lists.RemoveRange(lists);

                // Delete the user
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Models.User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {

            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);

        }


        public async Task<Models.User> UpdateUserAsync(Guid userId, User userUpdate)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null) return null;
            existingUser.Email = userUpdate.Email;
            existingUser.Password = userUpdate.Password;
            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}