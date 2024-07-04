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

        public Models.List CreateList(Models.List list)
        {
            var createdList = context.Lists.Add(list);
            return createdList.Entity;
        }

        public void DeleteList(String id)
        {
            context.Lists.Remove(context.Lists.Find(id));
        }

        public IEnumerable<Models.List> GetAllLists()
        {
            var lists = context.Lists;
            return lists;
        }

        public Models.List GetList(String id)
        {
            var list = context.Lists.Find(id);
            return list;
        }

        public Models.List UpdateList(String id, Models.List list)
        {
            var updatedList = context.Lists.Update(list);
            return updatedList.Entity;
        }
    }
}