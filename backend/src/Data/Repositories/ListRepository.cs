using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ToDoListAPI.Data.Repositories
{
    public class ListRepository : IListRepository
    {
        private ToDoListContext context;

        public ListRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public Models.List CreateList(Models.List list, string userId)
        {
            list.UserId = userId; // Ensure the list is associated with the user
            var createdList = context.Lists.Add(list);
            context.SaveChanges(); // Save changes here if not using a unit of work pattern
            return createdList.Entity;
        }

        public bool DeleteList(string id, string userId)
        {
            var list = context.Lists.FirstOrDefault(l => l.Id == id && l.UserId == userId);
            if (list == null)
            {
                return false; // List not found, return false
            }

            context.Lists.Remove(list);
            int changes = context.SaveChanges(); // Store the number of changes

            return changes > 0; // Return true if any changes were made, otherwise false
        }

        public IEnumerable<Models.List> GetAllLists(string userId)
        {
            return context.Lists.Where(l => l.UserId == userId).ToList();
        }

        public Models.List GetList(string id, string userId)
        {
            return context.Lists.FirstOrDefault(l => l.Id == id && l.UserId == userId);
        }

        public Models.List UpdateList(string id, Models.List list, string userId)
        {
            var existingList = context.Lists.FirstOrDefault(l => l.Id == id && l.UserId == userId);
            if (existingList != null)
            {
                context.Entry(existingList).CurrentValues.SetValues(list);
                context.SaveChanges(); // Save changes here if not using a unit of work pattern
                return existingList;
            }
            return null;
        }
    }
}