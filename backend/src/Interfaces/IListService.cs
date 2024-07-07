using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{

  public interface IListService


  {
    IEnumerable<ListDto> GetAllLists(String userId);
    bool DeleteList(String id, String userId);
    ListDto GetList(String id, String userId);
    ListDto UpdateList(String id, ListDto list, String userId);
    ListDto CreateList(ListDto list, String userId);
  }
}