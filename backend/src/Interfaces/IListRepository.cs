using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces

{
    public interface IListRepository
    {
        IEnumerable<List> GetAllLists(String userId);
        void DeleteList(String id, String userId);
        List GetList(String id, String userId);
        List UpdateList(String id, List list, String userId);
        List CreateList(List list, String userId);

    }

}