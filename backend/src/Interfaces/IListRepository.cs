using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces

{
    public interface IListRepository
    {
        IEnumerable<List> GetAllLists();
        void DeleteList(int id);
        List GetList(int id);
        List UpdateList(int id, List list);
        List CreateList(List list);

    }

}