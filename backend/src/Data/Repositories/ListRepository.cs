using ToDoListAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Data.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly ToDoListContext _context;

        public ListRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<Models.List> CreateListAsync(Models.List list, Guid userId)
        {
            var createdList = await _context.Lists.AddAsync(list);

            await _context.SaveChangesAsync();
            return createdList.Entity;
        }

        public async Task<bool> DeleteListAsync(Guid listId, Guid userId)
        {
            var list = await GetListByIdAndUserId(listId, userId);
            if (list == null) return false;
            _context.Lists.Remove(list);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Models.List>> GetAllListsAsync(Guid userId)
        {
            return await _context.Lists.Where(l => l.UserId == userId).ToListAsync();
        }

        public async Task<Models.List> GetListAsync(Guid listId, Guid userId)
        {
            return await GetListByIdAndUserId(listId, userId);
        }

        public async Task<Models.List> UpdateListAsync(Guid listId, Models.List list, Guid userId)
        {
            var existingList = await GetListByIdAndUserId(listId, userId);
            if (existingList == null) return null;
            existingList.Title = list.Title;
            existingList.Description = list.Description;
            existingList.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return existingList;
        }

        private async Task<Models.List> GetListByIdAndUserId(Guid listId, Guid userId)
        {
            return await _context.Lists.FirstOrDefaultAsync(l => l.ListId == listId && l.UserId == userId);
        }
    }
}