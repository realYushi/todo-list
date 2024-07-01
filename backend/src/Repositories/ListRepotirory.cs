using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
namespace ToDoListAPI.Repositories
{
    public class ListRepository : IListRepository
    {
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