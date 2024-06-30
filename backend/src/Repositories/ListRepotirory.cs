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

        public void DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<List> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public List GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List UpdateList(int id, List list)
        {
            throw new NotImplementedException();
        }
    }
}