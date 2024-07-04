using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
namespace ToDoListAPI.Data.Repositories
{
    public class ListRepository : IListRepository
    {
        private ToDoListContext context;

        public ListRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public List CreateList(List list)
        {
            throw new NotImplementedException();
        }

        public void DeleteList(String id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<List> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public List GetList(String id)
        {
            throw new NotImplementedException();
        }

        public List UpdateList(String id, List list)
        {
            throw new NotImplementedException();
        }
    }
}