using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces

{
    public interface IListRepository
    {
        IEnumerable<List> GetAllLists();
        void DeleteList(String id);
        List GetList(String id);
        List UpdateList(String id, List list);
        List CreateList(List list);

    }

}