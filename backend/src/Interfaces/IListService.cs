using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{

  public interface IListService


  {
    IEnumerable<ListDto> GetAllLists();
    void DeleteList(String id);
    ListDto GetList(String id);
    ListDto UpdateList(String id, ListDto list);
    ListDto CreateList(ListDto list);
  }
}